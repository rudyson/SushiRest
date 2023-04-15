using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SushiRest.Api.Contexts;
using SushiRest.Api.Dto;
using SushiRest.Api.Entities;
using SushiRest.Api.Repositories;
using SushiRest.Api.Repositories.Services;

namespace SushiRest.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
	private readonly ILogger<ProductsController> _logger;
	private readonly IMapper _mapper;
	private readonly IProductRepository _repository;
	
	public ProductsController(
		ILogger<ProductsController> logger,
		IMapper mapper,
		IProductRepository repository)
	{
		_logger = logger;
		_mapper = mapper;
		_repository = repository;
	}
	[HttpGet(Name = "Get all products")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductMenuDto>))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
	public async Task<IActionResult> Get(
		int? limit,
		string? order,
		[FromQuery] IEnumerable<Guid>? tags,
		Guid? category,
		int page = 1)
	{
		try
		{
			var products = await _repository.GetProductsAsync(limit,order,tags,category,page);
			return products.IsNullOrEmpty() ? NotFound() : Ok(products);
		}
		catch (Exception ex) 
		{ 
			_logger.LogError($"Something went wrong inside Get action: {ex.Message}"); 
			return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
		} 
	}
	[HttpGet("recommended",Name = "Get recommended products")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductTopDto>))]
	[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
	public async Task<IActionResult> Get(
		int? items)
	{
		try
		{
			var products = await _repository.GetProductsRecommendedAsync(items);
			return products.IsNullOrEmpty() ? NotFound() : Ok(products);
		}
		catch (Exception ex) 
		{ 
			_logger.LogError($"Something went wrong inside Get action: {ex.Message}"); 
			return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); 
		} 
	}
}