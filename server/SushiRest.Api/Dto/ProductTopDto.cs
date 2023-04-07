namespace SushiRest.Api.Dto;

public class ProductTopDto : EntityDto
{
	public string? Cover { get; set; }
	public string? Title { get; set; }
	public string? Description { get; set; }
	public decimal? Rating { get; set; }
	public int Pieces { get; set; }
	public decimal Weight { get; set; }
	public decimal Price { get; set; }
}