using System.ComponentModel.DataAnnotations;

namespace SushiRest.Api.Entities;
/// <summary>
/// Address model to use it in orders of products
/// </summary>
public class Delivery : Entity
{
	[DataType(DataType.Text)]
	public string? City { get; set; }
	[DataType(DataType.Text)]
	public string? Street { get; set; }
	[DataType(DataType.Text)]
	public string? House { get; set; }
	[DataType(DataType.Text)]
	public string? Entrance { get; set; }
	[DataType(DataType.Text)]
	public string? Apartment { get; set; }
	[DataType(DataType.Text)]
	public string? Floor { get; set; }
	
	#region EF Relations
	
	public Account? Owner { get; set; }
	
	#endregion
}