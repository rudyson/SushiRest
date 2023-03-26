using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using sushirestapi.Entities;

namespace sushirestapi.Models;

public class Order
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public Guid Id { get; set; }
	[DataType(DataType.Date)]
	public DateTime Date { get; set; }
	public Promo? Promo { get; set; }
	public Delivery? Address { get; set; }
	public Payment? Card { get; set; }
	// TotalPrice
	// Description
}