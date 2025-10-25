using KonditoriPallasSite.Models;
using Microsoft.EntityFrameworkCore;

namespace KonditoriPallasSite.Data
{
	public static class SeedData
	{
		public static void Initialize(ApplicationDbContext context)
		{
			// Om databasen redan har data, gör inget
			if (context.Categories.Any() || context.Products.Any())
			{
				return;
			}

			// Lägg till kategorier
			var categories = new[]
			{
				new Category { Name = "Tårtor" },
				new Category { Name = "Bageri" },
				new Category { Name = "Lunch" }
			};

			context.Categories.AddRange(categories);
			context.SaveChanges();

			// Lägg till produkter
			var products = new[]
			{
				new Product { Name = "Prinsesstårta", Description = "Klassisk grön marsipantårta", Price = 189, Category = categories[0] },
				new Product { Name = "Kanelbulle", Description = "Nygräddad med kanel och socker", Price = 25, Category = categories[1] },
				new Product { Name = "Smörgås", Description = "Rågbröd med ost och skinka", Price = 45, Category = categories[2] }
			};

			context.Products.AddRange(products);
			context.SaveChanges();
		}
	}
}
