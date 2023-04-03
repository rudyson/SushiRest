using Microsoft.EntityFrameworkCore;
using SushiRest.Api.Contexts;
using SushiRest.Api.Entities;

namespace SushiRest.Api.Repositories;

public class AccountRepository :
	IBaseCrudRepository<Account>,
	IBaseCrudRepositoryAsync<Account>
{
	private readonly SushiRestDbContext _context;

	public AccountRepository(SushiRestDbContext context)
	{
		_context = context;
	}


	public void Add(Account account)
	{
		_context.Accounts!.Add(account);
		_context.SaveChanges();
	}

	public IQueryable<Account> GetAll(int? limit, int? page)
	{
		return _context.Accounts!
			.Select(a => a); /*
			limit == null
				? _context.Accounts!
					.Select(a => a)
				: _context.Accounts!.Skip((page ?? 0 - 1)*limit).Take(limit);
				*/
	}

	public Account GetOne(Guid guid)
		=>_context.Accounts!.FirstOrDefault(a=>a.Id==guid)!;

	public void Update(Account account)
	{
		_context.Accounts!.Update(account);
		_context.SaveChanges();
	}

	public void Delete(Account account)
	{
		_context.Accounts!.Remove(account);
		_context.SaveChanges();
	}

	public async Task AddAsync(Account account)
	{
		await _context.Accounts!.AddAsync(account);
		await _context.SaveChangesAsync();
	}

	public async Task<IQueryable<Account>> GetAllAsync(int? limit, int? page)
	{
		var accounts =  await _context.Accounts!.ToListAsync();
		return accounts.AsQueryable();
	}

	public async Task<Account> GetOneAsync(Guid guid)
	=>(await _context.Accounts!.FirstOrDefaultAsync(a=>a.Id==guid))!;

	public async Task UpdateAsync(Account account)
	{
		_context.Accounts!.Update(account);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(Account account)
	{
		_context.Accounts!.Remove(account);
		await _context.SaveChangesAsync();
	}
}