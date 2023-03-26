using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace sushirestapi.Entities;

public class Promo : Entity
{
	[Required]
	public string? Code { get; set; }
	
	// Promo discount percentage
	[Range(1,100)]
	public int Discount { get; set; }
	
	[DisplayFormat(DataFormatString = "{0:yyyy.MM.dd_HH.mm.ss}", ApplyFormatInEditMode=true)]
	[DataType(DataType.DateTime)]
	public DateTime Created { get; set; }
	
	[DisplayFormat(DataFormatString = "{0:yyyy.MM.dd_HH.mm.ss}", ApplyFormatInEditMode=true)]
	[DataType(DataType.DateTime)]
	public DateTime Expiration { get; set; }
}