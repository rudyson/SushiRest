using Microsoft.EntityFrameworkCore;
using SushiRest.Api.Contexts;
using SushiRest.Api.Entities;

namespace SushiRest.Api.Repositories;

public class ProductRepository : IProductRepository
{
	private readonly SushiRestDbContext _context;

	public ProductRepository(SushiRestDbContext context)
	{
		_context = context;
	}
/*
	public ICollection<Product> GetProducts(int ? limit, int page = 1)
	{
		var products = _context
			.Products!
			.OrderBy(p => p.Id)
			.ToList();
		return limit==null?
			products
			:
			products
				.Skip((page-1)*limit.Value)
				.Take(limit.Value)
				.ToList();
	}*/
	public async Task<IEnumerable<Product>> GetProductsAsync(int ? limit, int page = 1)
	{
		return
			limit.HasValue
				? await _context.Products!
					.OrderBy(p => p.Id)
					.Select(p => p)
					.Skip((page - 1) * limit.Value)
					.Take(limit.Value)
					.ToListAsync()
				: await _context.Products!
					.OrderBy(p => p.Id)
					.Select(p => p)
					.ToListAsync();
	}
}