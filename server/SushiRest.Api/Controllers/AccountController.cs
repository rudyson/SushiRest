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

	[HttpPost("Register", Name = "Register new account")]
	public async Task<IActionResult> RegisterAsync([FromBody] RegistrationDto credentials)
	{
		if (!ModelState.IsValid) return BadRequest("Wrong properties in provided data");

		var result = await _userService.RegisterUserAsync(credentials);
		return result.Sussessfull ? Ok(result) : BadRequest(result);
	}
	[HttpPost("Login", Name = "Login into account")]
	public async Task<IActionResult> LoginAsync([FromBody] LoginDto credentials)
	{
		if (!ModelState.IsValid) return BadRequest("Wrong properties in provided data");

		var result = await _userService.LoginUserAsync(credentials);
		return result.Sussessfull ? Ok(result) : BadRequest(result);
	}
}