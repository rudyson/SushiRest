using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SushiRest.Api.Dto;
using SushiRest.Api.Repositories;
using SushiRest.Api.Repositories.Services;

namespace SushiRest.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
	private readonly ILogger<CategoriesController> _logger;
	private readonly ICategoryRepository _repository;
	
	public CategoriesController(
		ILogger<CategoriesController> logger,
		ICategoryRepository repository)
	{
		_logger = logger;
		_repository = repository;
	}
	[HttpGet(Name = "Get all categories")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CategoryDto>))]
	[ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
	[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
	public async Task<IActionResult> Get()
	{
		try
		{
			var fetchedProducts = await _repository.GetCategoriesAsync();
			return fetchedProducts.IsNullOrEmpty() ? NotFound("Categories not found") : Ok(fetchedProducts);
		}
		catch (Exception ex) 
		{ 
			_logger.LogError($"Something went wrong inside Get action: {ex.Message}"); 
			return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); 
		} 
	}
}