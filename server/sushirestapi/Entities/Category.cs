﻿using System.ComponentModel.DataAnnotations;

namespace sushirestapi.Entities;
/// <summary>
/// Category of product
/// </summary>
public class Category : Entity
{
	[Required]
	public string? Name { get; set; }
	
	#region EF Relations
	
	public ICollection<Product>? Products { get; set; }
	
	#endregion
}