using System.ComponentModel.DataAnnotations;

namespace SushiRest.Api.Dto.Account;

public class LoginDto
{
	[DataType(DataType.PhoneNumber)]
	public string? PhoneNumber  { get; set; }
	
	[DataType(DataType.EmailAddress)]
	public string? Email  { get; set; }
	
	[Required]
	[DataType(DataType.Password)]
	public string? Password  { get; set; }
}