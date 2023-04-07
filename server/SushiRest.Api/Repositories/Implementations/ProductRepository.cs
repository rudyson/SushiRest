using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SushiRest.Api.Contexts;
using SushiRest.Api.Dto;
using SushiRest.Api.Entities;
using SushiRest.Api.Repositories.Services;

namespace SushiRest.Api.Repositories.Implementations;

public class ProductRepository : IProductRepository
{
	private readonly SushiRestDbContext _context;
	private readonly IMapper _mapper;

	public ProductRepository(SushiRestDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	public async Task<IEnumerable<ProductMenuDto>> GetProductsAsync(int? pageSize, string? orderBy, IEnumerable<Guid>? tags, Guid? category, int pageNumber = 1)
	{// Category > Tags > Map > Order > Pages

		// Categorizing
		var productCategorized = category.HasValue ?
			await _context.Products!.Where(p => p.Category!.Id == category.Value).ToListAsync() :
			await _context.Products!.Select(p => p).ToListAsync();
		
		// Tagging
		var productTagged = tags.IsNullOrEmpty() ? productCategorized :
			productCategorized.Where(p => p.Tags!.All(t => tags.Any(x => x.Equals(t.Id))));
		
		// Mapping
		var productsMapped = _mapper.Map<List<Product>,List<ProductMenuDto>>(productTagged.ToList());
		
		// Ordering
		var productOrdered = productsMapped;
		if (orderBy!=null)
		{
			productOrdered = orderBy.ToLower() switch
			{
				"popular" => productOrdered.OrderBy(p => p.Rating).ToList(),
				"cheap" => productOrdered.OrderBy(p => p.Price).ToList(),
				"expensive" => productOrdered.OrderByDescending(p => p.Price).ToList(),
				_ => productOrdered
			};
		}
		
		// Pagination
		var productsPaginated = pageSize.HasValue
			? productOrdered
				.Skip((pageNumber - 1) * pageSize.Value)
				.Take(pageSize.Value)
			: productOrdered;
		
		return productsPaginated;
	}

	public async Task<IEnumerable<ProductMenuDto>> GetProductsAsync(int ? pageSize, int pageNumber = 1)
		{
			// Pagination
			var productsFetched = pageSize.HasValue
				? await _context.Products!
					.OrderBy(p => p.Id)
					.Select(p => p)
					.Skip((pageNumber - 1) * pageSize.Value)
					.Take(pageSize.Value)
					.ToListAsync()
				: await _context.Products!
					.OrderBy(p => p.Id)
					.Select(p => p)
					.ToListAsync();
			
			// Mapping
			var productsMapped = _mapper.Map<List<Product>,List<ProductMenuDto>>(productsFetched.ToList());
			
			return productsMapped;
		}

	public async Task<IEnumerable<ProductMenuDto>> GetProductsAsync()
	{
		// Fetching
		var productsFetched = await _context.Products!
			.OrderBy(p => p.Id)
			.Select(p => p)
			.ToListAsync();
		
		// Mapping
		var productsMapped = _mapper.Map<List<Product>,List<ProductMenuDto>>(productsFetched.ToList());
		
		return productsMapped;
	}

	public async Task<IEnumerable<ProductTopDto>> GetProductsRecommendedAsync(int? items)
	{
		// Fetching
		var productsFetched = await _context.Products!
			.ToListAsync();
		
		// Mapping
		var productsMapped = _mapper.Map<List<Product>,List<ProductTopDto>>(productsFetched.ToList());
		
		// Ordering

		var productsSorted = productsMapped.OrderByDescending(p => p.Rating);
		
		// Taking

		var result = items.HasValue ? productsSorted.Take(items.Value) : productsSorted;
		
		return result;
	}
}