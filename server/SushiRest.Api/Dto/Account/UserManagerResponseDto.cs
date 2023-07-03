namespace SushiRest.Api.Dto.Account;

public class UserManagerResponseDto
{
	public string? Message { get; init; } = string.Empty;
	public bool Successful { get; init; }
	public IEnumerable<string>? Errors { get; set; }
	public DateTime ExpiresAtDate  { get; set; }
}