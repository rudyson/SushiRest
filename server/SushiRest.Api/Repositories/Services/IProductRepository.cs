using SushiRest.Api.Dto;

namespace SushiRest.Api.Repositories.Services;

public interface IProductRepository
{
	/// <summary>
	/// Gets paginated product list ordered by provided params
	/// </summary>
	/// <param name="pageSize">Amount of items per page</param>
	/// <param name="orderBy">Order options [null,"popular","cheap","expensive"]</param>
	/// <param name="tags">Tags of products for filtering by them</param>
	/// <param name="category">Category of product</param>
	/// <param name="pageNumber">Number of current page</param>
	/// <returns></returns>
	public Task<IEnumerable<ProductMenuDto>> GetProductsAsync(int? pageSize, string? orderBy, IEnumerable<Guid>? tags, Guid? category, int pageNumber = 1);
	/// <summary>
	/// Gets paginated product list without ordering
	/// </summary>
	/// <param name="pageSize">Amount of items per page</param>
	/// <param name="pageNumber">Number of current page</param>
	/// <returns></returns>
	public Task<IEnumerable<ProductMenuDto>> GetProductsAsync(int? pageSize, int pageNumber = 1);
	/// <summary>
	/// Gets all product list without ordering and pagination
	/// </summary>
	/// <returns></returns>
	public Task<IEnumerable<ProductMenuDto>> GetProductsAsync();
	
}