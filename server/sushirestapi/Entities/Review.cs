using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace sushirestapi.Entities;

public class Review : Entity
{
	[Required]
	public Guid ReviewerId { get; set; }
	
	[Required]
	[Precision(1, 1)]
	[Range(1,5)]
	public decimal Rate { get; set; }
	
	[Required]
	public string? Description { get; set; }
	// USER-ABOUT Status (Regular customer / Recently ordered)

	#region EF Relations

	[Required]
  public Account? ReviewedBy { get; set; }

	#endregion
	
}