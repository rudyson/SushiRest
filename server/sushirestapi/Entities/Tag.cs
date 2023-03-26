using System.ComponentModel.DataAnnotations;

namespace sushirestapi.Entities;
/// <summary>
/// Tag for product
/// </summary>
public class Tag : Entity
{
	[Required]
	public string? Name { get; set; }
	
	#region EF Relations
	
	public ICollection<Product>? Products { get; set; }
	
	#endregion
}