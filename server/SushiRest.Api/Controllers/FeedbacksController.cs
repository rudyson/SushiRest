using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SushiRest.Api.Dto;
using SushiRest.Api.Repositories.Services;

namespace SushiRest.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeedbacksController : ControllerBase
{
	private readonly ILogger<FeedbacksController> _logger;
	private readonly IFeedbackRepository _repository;
	
	public FeedbacksController(
		ILogger<FeedbacksController> logger,
		IFeedbackRepository repository)
	{
		_logger = logger;
		_repository = repository;
	}
	[HttpGet(Name = "Get feedbacks")]
	[ProducesResponseType(200, Type = typeof(IEnumerable<FeedbackDto>))]
	[ProducesResponseType(404, Type = typeof(string))]
	[ProducesResponseType(500, Type = typeof(string))]
	public async Task<IActionResult> Get(int ? items)
	{
		try
		{
			var fetchedFeedbacks = await _repository.GetFeedbacksAsync(items);
			return fetchedFeedbacks.IsNullOrEmpty() ? NotFound("Feedbacks not found") : Ok(fetchedFeedbacks);
		}
		catch (Exception ex) 
		{ 
			_logger.LogError($"Something went wrong inside Get action: {ex.Message}"); 
			return StatusCode(500, "Internal server error"); 
		} 
	}
}