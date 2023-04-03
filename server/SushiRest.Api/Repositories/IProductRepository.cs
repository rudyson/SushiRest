using SushiRest.Api.Entities;

namespace SushiRest.Api.Repositories;

public interface IProductRepository
{
	//public ICollection<Product> GetProducts(int? limit, int page = 1);
	public Task<IEnumerable<Product>> GetProductsAsync(int? limit, int page = 1);
}