using System.ComponentModel.DataAnnotations;
using SushiRest.Api.Entities.Identity;

namespace SushiRest.Api.Entities;

/// <summary>
/// This model is designed to interact with the database and
/// securely store information about payment methods
/// </summary>
public class Payment : Entity
{
	[Required]
	[DataType(DataType.Text)]
	public string? FirstName { get; set; }
	[Required]
	[DataType(DataType.Text)]
	public string? LastName { get; set; }
	[Required]
	[DataType(DataType.CreditCard)]
	public UInt64 Number { get; set; }
	[Required]
	public int ExpiredMonth { get; set; }
	[Required]
	public int ExpiredYear { get; set; }
	[Required]
	public int Cvv { get; set; }
	
	#region EF Relations
	
	public ApplicationUser? Owner { get; set; }
	
	#endregion
}