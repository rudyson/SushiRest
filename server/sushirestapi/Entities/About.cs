using System.ComponentModel.DataAnnotations;

namespace sushirestapi.Entities;
/// <summary>
/// This class represents a card for about us section
/// </summary>
public class About : Entity
{
	[DataType(DataType.ImageUrl)]
	public string? Cover { get; set; }
	
	[Required]
	public string? Title { get; set; }
	
	[Required]
	public string? Description { get; set; }
}