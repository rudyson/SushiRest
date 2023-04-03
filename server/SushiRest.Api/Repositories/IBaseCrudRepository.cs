namespace SushiRest.Api.Repositories;

public interface IBaseCrudRepository<T>
{
	void Add(T entity);
	IQueryable<T> GetAll(int ? limit, int ? page);
	T GetOne(Guid guid);
	void Update(T entity);
	void Delete(T entity);
}