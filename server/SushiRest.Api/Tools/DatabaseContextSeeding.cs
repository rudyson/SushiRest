using Microsoft.EntityFrameworkCore;
using SushiRest.Api.Contexts;
using SushiRest.Api.Entities;

namespace SushiRest.Api.Tools;
/// <summary>
/// Initial database seeding for filling context with start values
/// </summary>
public class DatabaseContextSeeding
{
	private readonly SushiRestDbContext _context;
	private readonly ILogger<DatabaseContextSeeding> _logger;
	/// <summary>
	/// DatabaseContextSeeding seeds data into empty tables to fill them with initial data
	/// </summary>
	/// <param name="context">SushiRestDbContext instance</param>
	/// <param name="logger">Logging Dependency Injection</param>
	public DatabaseContextSeeding(SushiRestDbContext context, ILogger<DatabaseContextSeeding> logger)
	{
		_context = context;
		_logger = logger;
	}

	public async Task Seed()
	{
		await SeedAbout();
		await SeedTags();
		await SeedCategories();
		await SeedProducts();
	}

	private async Task SeedAbout()
	{
		if (await _context.Abouts!.AnyAsync()) return;
		var abouts = new List<About>
		{
			new()
			{
				Title = "About SushiRest",
				Description =
					@"At our company, we take pride in our commitment to quality and customer satisfaction. Our success is a direct result of the hard work and dedication of our employees, who are truly the backbone of our business.

					Our team is made up of skilled professionals who are passionate about what they do. From our chefs and kitchen staff to our customer service representatives and management team, we are all committed to delivering the best possible experience for our customers.

					To ensure that our employees are equipped to succeed, we provide ongoing training and development opportunities, competitive wages and benefits packages, and a culture of open communication and collaboration. We believe in recognizing and rewarding our employees for their hard work and dedication, and fostering a positive and inclusive workplace culture where everyone feels valued and respected."
			},
			new()
			{
				Title = "Quality Products",
				Description =
					@"We believe that using the freshest and highest quality ingredients is the key to creating exceptional dishes that stand out from the competition. 

Our team of expert chefs are trained to use innovative techniques and creative combinations to create visually stunning and delicious dishes that exceed our customers' expectations. 

We also understand that dietary needs and preferences vary among our customers, which is why we offer a wide variety of dishes to cater to different tastes and lifestyles. Whether you're a seafood lover, a vegan, or have specific dietary restrictions, we have something to offer you.

From classic sushi rolls to unique and creative dishes, our menu is designed to cater to all tastes and preferences. We believe that food should not only taste great but also be visually appealing, which is why our chefs take great care in plating and presenting each dish with the utmost attention to detail."
			},
			new()
			{
				Title = "Customer Service",
				Description =
					@"Our team of friendly and knowledgeable staff are always available to answer any questions and provide recommendations to help our customers find the perfect product for their needs. We believe that great customer service starts with a positive attitude and a willingness to go above and beyond to make our customers happy.

Whether you're a first-time customer or a regular, our team is dedicated to making your experience with us a positive one. We understand that every customer is unique, which is why we take the time to listen to your needs and provide personalized service that is tailored to your preferences.

We also believe in being transparent and upfront with our customers about our products, pricing, and policies. We want our customers to feel confident and informed about their purchases, which is why we are always happy to provide detailed information and answer any questions they may have."
			},
			new()
			{
				Title = "Employee Profiling",
				Description =
					@"We understand that our employees are our greatest asset, which is why we invest in their training, development, and well-being. Each member of our team is carefully selected and trained to ensure they have the necessary skills and knowledge to provide exceptional service and deliver the highest quality products.

We also believe in providing a supportive and inclusive work environment where all team members feel valued and respected. We encourage open communication and collaboration, and we strive to create a culture of mutual respect and understanding. Our team members bring a wide range of perspectives and ideas to the table, which allows us to innovate and improve our products and services.

Overall, our commitment to employee profiling and diversity is a reflection of our core values and belief in the power of a diverse and inclusive workplace culture. We are proud of the talented individuals who make up our team and believe that their unique skills and perspectives are key to our success."
			}
		};
		_logger.Log(LogLevel.Debug, "Seeding abouts");
		await _context.Abouts!.AddRangeAsync(abouts);
		await _context.SaveChangesAsync();
	}

	private async Task SeedTags()
	{
		if (await _context.Tags!.AnyAsync()) return;
		var tags = new List<Tag>
		{
			new() { Name = "Salmon" },
			new() { Name = "Eel" },
			new() { Name = "Tuna" },
			new() { Name = "Shrimp" },
			new() { Name = "Squid" },
			new() { Name = "Perch" },
			new() { Name = "Snow crab" },
			new() { Name = "Masago caviar" },
			new() { Name = "Caviar" },
			new() { Name = "Mussels" },
			new() { Name = "Chuka algae" },
			new() { Name = "Meat" },
			new() { Name = "Vegetable" },
			new() { Name = "With seafood" }
		};
		_logger.Log(LogLevel.Debug, "Seeding tags");
		await _context.Tags!.AddRangeAsync(tags);
		await _context.SaveChangesAsync();
	}
	private async Task SeedCategories()
	{
		if (await _context.Categories!.AnyAsync()) return;
		var categories = new List<Category>
		{
			new() { Name = "Set" },
			new() { Name = "Roll" },
			new() { Name = "Wok" },
			new() { Name = "Salad" }
		};
		_logger.Log(LogLevel.Debug, "Seeding categories");
		await _context.Categories!.AddRangeAsync(categories);
		await _context.SaveChangesAsync();
	}

	private async Task SeedProducts()
	{
		var defaultCategory = await _context.Categories!.FirstOrDefaultAsync(c => c.Name == "Roll");
		if (await _context.Products!.AnyAsync()) return;
		if (defaultCategory==null) return;
		var products = new List<Product>
		{
			new()
			{
				Title = "Big fish XXL",
				Pieces = 45,
				Weight = 2.9m,
				Description = @"Roll with salmon fillet, Philadelphia cheese, mango and Tamago. Roll with salmon fillet, Philadelphia cheese, dor blue, Tamago and pear. Roll with panko salmon, Tamago,and tobiko caviar.",
				Category = defaultCategory,
				Price = 23.51m
			},
			new()
			{
				Title = "The Dragon XXL",
				Pieces = 60,
				Weight = 3.6m,
				Description = @"Roll with panko chicken, cucumber, tomatoes, lettuce and Caesar dressing in tobiko caviar. Roll with salmon and panko eel, Philadelphia cheese, Tamago, cucumber, tobiko caviar, avocado, sesame seeds and unagi sauce.",
				Category = defaultCategory,
				Price = 30.87m
			},
			new()
			{
				Title = "Sushi With Salmon",
				Pieces = 12,
				Weight = 0.8m,
				Description = @"Rice, nori, cream cheese, Iceberg lettuce, snow crab, salmon, spicy sauce.",
				Category = defaultCategory,
				Price = 6.12m
			},
			new()
			{
				Title = "Wakame futomaki",
				Pieces = 8,
				Weight = 0.8m,
				Description = @"Rice, nori, snow crab, Japanese mayonnaise, scrambled eggs, avocado, Masago caviar, Unagi sauce.",
				Category = defaultCategory,
				Price = 2.89m
			},
			new()
			{
				Title = "Kazumi",
				Pieces = 8,
				Weight = 0.7m,
				Description = @"Rice, nori, cream cheese, avocado, tiger shrimp, salmon, masago caviar, spicy sauce.",
				Category = defaultCategory,
				Price = 4.47m
			},
			new()
			{
				Title = "Sakura",
				Pieces = 10,
				Weight = 0.9m,
				Description = @"Rice, nori, scrambled eggs, fried salmon, feta cheese, cucumber, cheddar cheese.",
				Category = defaultCategory,
				Price = 5.35m
			},
			new()
			{
				Title = "Bali set XXL",
				Pieces = 55,
				Weight = 2.9m,
				Description = @"Cream cheese, fresh cucumber, avocado, salmon, tuna, green onion, tuna chips, spice sauce, eel, rebel roll, California roll with crab, sesame roll.",
				Category = defaultCategory,
				Price = 25.35m
			},
			new()
			{
				Title = "Seth Diverse",
				Pieces = 50,
				Weight = 2.3m,
				Description = @"Chicken roll, grilled cheese roll with salmon, baguette roll, kaif roll, Philadelphia light.",
				Category = defaultCategory,
				Price = 22.14m
			}
		};
		_logger.Log(LogLevel.Debug, "Seeding products");
		await _context.Products!.AddRangeAsync(products);
		await _context.SaveChangesAsync();
	}
}