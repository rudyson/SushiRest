using SushiRest.Api.Dto.Account;

namespace SushiRest.Api.Repositories.Services;

public interface IUserService
{
	public Task<UserManagerResponseDto> RegisterUserAsync(RegistrationDto credentials);
	public Task<UserManagerResponseDto> LoginUserAsync(LoginDto credentials);
}