using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SushiRest.Api.Dto.Account;
using SushiRest.Api.Entities.Identity;
using SushiRest.Api.Repositories.Services;

namespace SushiRest.Api.Repositories.Implementations;

public class UserService : IUserService
{
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly IConfiguration _configuration;

	public UserService(
		UserManager<ApplicationUser> userManager,
		IConfiguration configuration)
	{
		_userManager = userManager;
		_configuration = configuration;
	}

	public async Task<UserManagerResponseDto> RegisterUserAsync(RegistrationDto credentials)
	{
		// Empty JSON
		if (credentials.Equals(null))
			return new UserManagerResponseDto
			{
				Sussessfull = false,
				Message = "Empty register model provided"
			};
		// User already exists
		if (await _userManager.FindByEmailAsync(credentials.Email!)!=null)
			return new UserManagerResponseDto
			{
				Sussessfull = false,
				Message = "User already exists"
			};

		var identityUser = new ApplicationUser
		{
			Email = credentials.Email,
			PhoneNumber = credentials.PhoneNumber,
			FirstName = credentials.FirstName,
			UserName = String.Join('-',new MailAddress(credentials.Email!).User, DateTime.Now.ToBinary())
		};
		var result = await _userManager.CreateAsync(identityUser, credentials.Password!);
		return new UserManagerResponseDto
		{
			Sussessfull = result.Succeeded,
			Message = result.Succeeded ? "User created" : "Something went wrong",
			Errors = result.Errors.Select(e => e.Description)
		};
	}

	public async Task<UserManagerResponseDto> LoginUserAsync(LoginDto credentials)
	{
		var user = await _userManager.Users
			.SingleOrDefaultAsync(u => 
				u.Email == credentials.Email
				|| u.PhoneNumber== credentials.PhoneNumber);
		if (user == null)
		{
			return new UserManagerResponseDto
			{
				Sussessfull = false,
				Message = "User not found"
			};
		}

		var result = await _userManager.CheckPasswordAsync(user, credentials.Password!);
		if (!result)
		{
			return new UserManagerResponseDto
			{
				Sussessfull = false,
				Message = "Wrong password specified"
			};
		}

		var claims = new[]
		{
			new Claim("Email", credentials.Email!),
			new Claim(ClaimTypes.NameIdentifier, user.Id)
		};

		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JsonWebToken:SecretKey"]!));
		
		var token = new JwtSecurityToken(
			issuer: _configuration["JsonWebToken:Issuer"],
			audience: _configuration["JsonWebToken:Audience"],
			claims: claims,
			expires: DateTime.Now.AddDays(30),
			signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

		return new UserManagerResponseDto
		{
			Message = new JwtSecurityTokenHandler().WriteToken(token),
			Sussessfull = true,
			ExpiresAtDate = token.ValidTo
		};
	}
}