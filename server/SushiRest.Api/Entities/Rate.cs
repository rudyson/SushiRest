using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SushiRest.Api.Entities;

public class Rate : Entity
{
	[Required]
	[Precision(1, 1)]
	[Range(1,5)]
	public decimal Value { get; set; }

	#region EF Relations

	[Required]
  public Account? RatedBy { get; set; }
  public Product? Product { get; set; }

	#endregion
}