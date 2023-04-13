using System.ComponentModel.DataAnnotations;
using SushiRest.Api.Entities.Identity;

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
	
	public ApplicationUser? Owner { get; set; }
	
	#endregion
}