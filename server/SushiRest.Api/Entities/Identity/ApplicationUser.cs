using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SushiRest.Api.Entities.Identity;
/// <summary>
/// User account with preferences
/// </summary>
public class ApplicationUser : IdentityUser
{
	#region Properties
	[Required]
	public string? FirstName  { get; set; }
	
	public string? LastName  { get; set; }
	/*
	[Required]
	[DataType(DataType.PhoneNumber)]
	public string? PhoneNumber  { get; set; }
	
	[Required]
	[DataType(DataType.EmailAddress)]
	public string? Email  { get; set; }
	
	[Required]
	[DataType(DataType.Password)]
	public string? Password  { get; set; } // [HASH SHA256]
*/
	#endregion
	
	#region EF Relations
	
	public ICollection<Payment>? Payments { get; set; }
	
	public ICollection<Delivery>? Deliveries { get; set; }

	public ICollection<Order>? Orders { get; set; }
	
	public ICollection<Rate>? Rates { get; set; }
	public ICollection<Review>? Reviews { get; set; }
	
	public DbImage? Avatar  { get; set; }

	#endregion
	
}