using System.ComponentModel.DataAnnotations;

namespace SushiRest.Api.Entities;
/// <summary>
/// User account with preferences
/// </summary>
public class Account : Entity
{
	#region Properties

	public string? FirstName  { get; set; }
	
	public string? LastName  { get; set; }
	
	[DataType(DataType.PhoneNumber)]
	public string? PhoneNumber  { get; set; }
	
	[DataType(DataType.EmailAddress)]
	public string? Email  { get; set; }
	
	[DataType(DataType.Password)]
	public string? Password  { get; set; } // [HASH SHA256]

	#endregion
	
	#region EF Relations
	
	public ICollection<Payment>? Payments { get; set; }
	
	public ICollection<Delivery>? Deliveries { get; set; }

	public ICollection<Order>? Orders { get; set; }
	
	public ICollection<Rate>? Rates { get; set; }
	public ICollection<Review>? Reviews { get; set; }

	#endregion
	
}