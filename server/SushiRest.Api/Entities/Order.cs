using System.ComponentModel.DataAnnotations;

namespace SushiRest.Api.Entities;
/// <summary>
/// Order entity model with order items
/// </summary>
public class Order : Entity
{
	#region Fields
	/// <summary>
	/// If null, Order is not completed
	/// </summary>
	[DataType(DataType.DateTime)]
	[DisplayFormat(DataFormatString = "{0:yyyy.MM.dd_HH.mm.ss}", ApplyFormatInEditMode=true)]
	public DateTime? Timestamp { get; set; }

	#endregion

	#region EF Relations
	public Promo? Promo { get; set; }
  	
	public Delivery? Address { get; set; }
  	
	[Required]
	public Payment? Card { get; set; }
  
	public ICollection<OrderItem>? OrderItems { get; set; }
	
	public Account? Owner { get; set; }
	
	#endregion
}