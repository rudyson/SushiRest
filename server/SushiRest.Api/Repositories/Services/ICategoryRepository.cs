using SushiRest.Api.Dto;

namespace SushiRest.Api.Repositories.Services;

public interface ICategoryRepository
{
	public Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
}