namespace SushiRest.Api.Repositories;

public interface IBaseCrudRepositoryAsync<T>
{
	Task AddAsync(T entity);
	Task<IQueryable<T>> GetAllAsync(int ? limit, int ? page);
	Task<T> GetOneAsync(Guid guid);
	Task UpdateAsync(T entity);
	Task DeleteAsync(T entity);
}