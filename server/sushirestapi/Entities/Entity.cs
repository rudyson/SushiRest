using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sushirestapi.Entities;
/// <summary>
/// Base class with GUID identifier
/// </summary>
public class Entity
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public Guid Id { get; set; }
}