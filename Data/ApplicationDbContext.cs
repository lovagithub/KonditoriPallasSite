using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KonditoriPallasSite.Models;

namespace KonditoriPallasSite.Data
{
	// Måste ärva från IdentityDbContext<ApplicationUser> (som i sin tur ärver DbContext)
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		// Den här konstruktorn är den EF Core förväntar sig
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options) { }

		// DbSet = tabeller
		public DbSet<Product> Products { get; set; } = default!;
		public DbSet<Category> Categories { get; set; } = default!;
		public DbSet<ContactMessage> ContactMessages { get; set; } = default!;
	}
}
