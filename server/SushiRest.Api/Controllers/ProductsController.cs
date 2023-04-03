using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SushiRest.Api.Contexts;
using SushiRest.Api.Dto;
using SushiRest.Api.Entities;
using SushiRest.Api.Repositories;

namespace SushiRest.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
	private readonly ILogger<ProductsController> _logger;
	private readonly IMapper _mapper;
	private readonly SushiRestDbContext _context;
	private readonly IProductRepository _repository;
	
	public ProductsController(
		ILogger<ProductsController> logger,
		IMapper mapper,
		IProductRepository repository,
		SushiRestDbContext context)
	{
		_logger = logger;
		_mapper = mapper;
		_context = context;
		_repository = repository;
	}
/*
	private static Tag[] _tags = new Tag[]
	{
		new Tag {Id=Guid.NewGuid(), Name = "Fruit"}
	};
	private Product[] _products = new Product[]
	{
		new Product { Id=Guid.NewGuid(), Title = "Apple", Price = 10, Tags = new List<Tag>{_tags[0]}},
		new Product { Id=Guid.NewGuid(), Title = "Mango", Price = 15, Tags = new List<Tag>{_tags[0]}},
		new Product { Id=Guid.NewGuid(), Title = "Peer", Price = 12.3m, Tags = new List<Tag>{_tags[0]}},
		new Product { Id=Guid.NewGuid(), Title = "Peach", Price = 17.2m, Tags = new List<Tag>{_tags[0]}}
	};

	*/

/*
	[HttpGet(Name = "GetAllProducts")]
	public IEnumerable<Product> GetAllProducts()
	{
		
		_logger.Log(LogLevel.Information,"GetAllProducts called");
		return _products;
	}
	[HttpGet("GetProductCat")]
	public async Task<IActionResult> GetProductCat()
	{
		var roll = await _context.Categories!.FirstOrDefaultAsync(c=>c.Name=="Roll");
		_logger.Log(LogLevel.Information,"GetProductCat called");
		if (roll!=null)
			return Ok(roll);
		else
		{
			return BadRequest(roll);
		}
	}*/
	
	//[HttpDelete("{id:int}", Name = "DeleteBookById")]
	[HttpGet(Name = "Get all products")]
	[ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
	[ProducesResponseType(500, Type = typeof(string))]
	public async Task<IActionResult> Get(int? limit, int page = 1)
	{
		try
		{

			var fetchedProducts = await _repository.GetProductsAsync(limit, page);
			var mappedProducts = _mapper
				.Map<List<Product>,List<ProductMenuDto>>(fetchedProducts.ToList());
			_logger.Log(LogLevel.Information,$"Returned {limit} products on {page} page from database.");
			//var ownersResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);
			//return Ok(ownersResult); 
			return Ok(mappedProducts);
		}
		catch (Exception ex) 
		{ 
			_logger.LogError($"Something went wrong inside Get action: {ex.Message}"); 
			return StatusCode(500, "Internal server error"); 
		} 
	}
}