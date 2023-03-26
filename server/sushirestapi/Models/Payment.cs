using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sushirestapi.Models;

/// <summary>
/// This model is designed for internal use in code.
/// Acts as an intermediary between the secure model stored in the database and the API
/// </summary>
public class Payment
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public Guid Id { get; set; }
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
}