using SushiRest.Api.Entities;

namespace SushiRest.Api.Repositories.Services;

public interface IProductRepository
{
	public Task<IEnumerable<Product>> GetProductsAsync(int? limit, int page = 1);
}