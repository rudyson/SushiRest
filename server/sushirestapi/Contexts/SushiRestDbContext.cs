using Microsoft.EntityFrameworkCore;
using sushirestapi.Entities;

namespace sushirestapi.Contexts;

public class SushiRestDbContext : DbContext
{
	public SushiRestDbContext(DbContextOptions<SushiRestDbContext> options): base (options)
	{
		
	}

	#region Members

	public DbSet<About>? Abouts { get; set; }
	public DbSet<Account>? Accounts { get; set; }
	public DbSet<Delivery>? Deliveries { get; set; }
	public DbSet<Order>? Orders { get; set; }
	public DbSet<Payment>? Payments { get; set; }
	public DbSet<Product>? Products { get; set; }
	public DbSet<Promo>? Promos { get; set; }
	public DbSet<Rate>? Rates { get; set; }
	public DbSet<Review>? Reviews { get; set; }
	public DbSet<Tag>? Tags { get; set; }
	public DbSet<Category>? Categories { get; set; }

	#endregion

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Account>()
			.HasMany(a => a.Deliveries)
			.WithOne(d => d.Owner);
		modelBuilder.Entity<Account>()
			.HasMany(a => a.Payments)
			.WithOne(p => p.Owner);
		modelBuilder.Entity<Account>()
			.HasMany(a => a.Orders)
			.WithOne(o => o.Owner);

		modelBuilder.Entity<Order>()
			.HasMany(o => o.Products);
		modelBuilder.Entity<Order>()
			.HasOne(o => o.Promo);
		modelBuilder.Entity<Order>()
			.HasOne(o => o.Address);
		modelBuilder.Entity<Order>()
			.HasOne(o => o.Card);

		modelBuilder.Entity<Product>()
			.HasMany(p => p.Tags)
			.WithMany(t => t.Products);
		modelBuilder.Entity<Product>()
			.HasMany(p => p.Rates)
			.WithOne(r=> r.Product);
		modelBuilder.Entity<Product>()
			.HasOne(p => p.Category)
			.WithMany(c => c.Products);
		
		modelBuilder.Entity<Rate>()
			.HasOne(r=>r.RatedBy)
			.WithMany(a=>a.Rates);
		
		modelBuilder.Entity<Review>()
			.HasOne(r=>r.ReviewedBy)
			.WithMany(a=>a.Reviews);
	}
}