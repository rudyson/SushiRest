namespace SushiRest.Api.Dto;
/// <summary>
/// DTO for Review entity
/// </summary>
public class FeedbackDto
{
	public string? Avatar { get; set; }
	public string? FullName { get; set; }
	public string? Description { get; set; }
	public decimal? Rating { get; set; }
}