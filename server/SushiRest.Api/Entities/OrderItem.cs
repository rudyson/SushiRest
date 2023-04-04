using System.ComponentModel.DataAnnotations;

namespace SushiRest.Api.Entities;
/// <summary>
/// An element in the shopping cart
/// </summary>
public class OrderItem : Entity
{
	#region Fields

	[Required]
	public Product? Product { get; set; }
	
	public int Amount { get; set; } = 1;

	#endregion

	#region EF Relations

	[Required]
	public Order? Order { get; set; }

	#endregion
}