using System.ComponentModel.DataAnnotations;

namespace sushirestapi.Entities;
/// <summary>
/// Order entity model with products
/// </summary>
public class Order : Entity
{
	[Required]
	[DataType(DataType.DateTime)]
	[DisplayFormat(DataFormatString = "{0:yyyy.MM.dd_HH.mm.ss}", ApplyFormatInEditMode=true)]
	public DateTime Timestamp { get; set; }

	#region EF Relations

	public Promo? Promo { get; set; }
  	
	public Delivery? Address { get; set; }
  	
	[Required]
	public Payment? Card { get; set; }
  
	public ICollection<Product>? Products { get; set; }
	
	public Account? Owner { get; set; }
	
	#endregion
}