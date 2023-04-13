using System.ComponentModel.DataAnnotations;

namespace SushiRest.Api.Dto.Account;

public class RegistrationDto
{
	[Required]
	public string? FirstName  { get; set; }
	[Required]
	[DataType(DataType.PhoneNumber)]
	public string? PhoneNumber  { get; set; }
	
	[Required]
	[DataType(DataType.EmailAddress)]
	public string? Email  { get; set; }
	
	[Required]
	[DataType(DataType.Password)]
	public string? Password  { get; set; }
}