using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using SushiRest.Api.Entities.Identity;

namespace SushiRest.Api.Entities;

public class Review : Entity
{
	[Required]
	[Precision(1, 1)]
	[Range(1,5)]
	public decimal Rate { get; set; }
	
	[Required]
	public string? Description { get; set; }
	// USER-ABOUT Status (Regular customer / Recently ordered)

	#region EF Relations

	[Required]
  public ApplicationUser? ReviewedBy { get; set; }

	#endregion
	
}