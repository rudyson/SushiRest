using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SushiRest.Api.Contexts;
using SushiRest.Api.Dto;
using SushiRest.Api.Entities;
using SushiRest.Api.Repositories.Services;

namespace SushiRest.Api.Repositories.Implementations;

public class CategoryRepository : ICategoryRepository
{
	private readonly SushiRestDbContext _context;
	private readonly IMapper _mapper;

	public CategoryRepository(SushiRestDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
	{
		var fetchedCategories = await _context.Categories!
			.OrderBy(p => p.Id)
			.Select(p => p)
			.ToListAsync();
		var mappedCategories = _mapper
			.Map<List<Category>,List<CategoryDto>>(fetchedCategories.ToList());
		return mappedCategories;
	}
}