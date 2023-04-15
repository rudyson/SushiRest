using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SushiRest.Api.Dto.Account;
using SushiRest.Api.Repositories.Services;

namespace SushiRest.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
	private readonly ILogger<AccountController> _logger;
	private readonly IUserService _userService;
	
	public AccountController(
		ILogger<AccountController> logger,
		IUserService userService)
	{
		_logger = logger;
		_userService = userService;
	}

	[AllowAnonymous]
	[HttpPost("Register", Name = "Register new account")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserManagerResponseDto))]
	[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
	public async Task<IActionResult> RegisterAsync([FromBody] RegistrationDto credentials)
	{
		if (!ModelState.IsValid) return BadRequest("Wrong properties in provided data");

		var result = await _userService.RegisterUserAsync(credentials);
		return result.Sussessfull ? Ok(result) : BadRequest(result);
	}
	[AllowAnonymous]
	[HttpPost("Login", Name = "Login into account")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserManagerResponseDto))]
	[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
	public async Task<IActionResult> LoginAsync([FromBody] LoginDto credentials)
	{
		if (!ModelState.IsValid) return BadRequest("Wrong properties in provided data");

		var result = await _userService.LoginUserAsync(credentials);
		return result.Sussessfull ? Ok(result) : BadRequest(result);
	}
	
	[Authorize]
	[HttpGet("Test", Name = "Test auth")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Claim))]
	[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Claim))]
	[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Claim))]
	public IActionResult Demo()
	{
		var userId = User.FindFirst(ClaimTypes.NameIdentifier);
		return userId != null ? Ok(userId) : BadRequest(userId);
	}
}