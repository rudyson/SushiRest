using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SushiRest.Api.Entities;
/// <summary>
/// Base product model for any position in restaurant menu
/// </summary>
public class Product : Entity
{
	[Required]
	public string? Title { get; set; }
	// Parameters
	[DefaultValue(1)]
	public int Pieces { get; set; }
	[Precision(16, 2)]
	public decimal Weight { get; set; } // Value must be set in grams
	[Required]
	public string? Description { get; set; }
	[DataType(DataType.Currency)]
	[Precision(16, 2)]
	public decimal Price { get; set; }


	#region EF Relations

	public ICollection<Rate>? Rates { get; set; }
	public ICollection<Tag>? Tags { get; set; }
	public Category? Category { get; set; }
	// Thumbnails
	public DbImage? TopPosThumbnail { get; set; }
	public DbImage? DefaultThumbnail { get; set; }

	#endregion
}