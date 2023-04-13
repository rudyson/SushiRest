using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SushiRest.Api.Entities;
using SushiRest.Api.Entities.Identity;

namespace SushiRest.Api.Contexts;

public class SushiRestDbContext : IdentityDbContext<ApplicationUser>
{
	public SushiRestDbContext(DbContextOptions<SushiRestDbContext> options): base (options)
	{
		
	}

	#region Migration builder tutorial

	/*
	 * dotnet ef migrations add MigrationName --context SushiRestDbContext
	 * dotnet ef database update --context SushiRestDbContext
	 */

	#endregion
	
	#region Members

	public DbSet<About>? Abouts { get; set; }
	public DbSet<ApplicationUser>? Accounts { get; set; }
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
		base.OnModelCreating(modelBuilder);
		
		modelBuilder.Entity<ApplicationUser>()
			.HasMany(a => a.Deliveries)
			.WithOne(d => d.Owner);
		modelBuilder.Entity<ApplicationUser>()
			.HasMany(a => a.Payments)
			.WithOne(p => p.Owner);
		modelBuilder.Entity<ApplicationUser>()
			.HasMany(a => a.Orders)
			.WithOne(o => o.Owner);

		modelBuilder.Entity<Order>()
			.HasMany(o => o.OrderItems)
			.WithOne(o => o.Order);
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