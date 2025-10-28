using Microsoft.AspNetCore.Mvc;
using KonditoriPallasSite.Data;
using KonditoriPallasSite.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace KonditoriPallasSite.Controllers
{
	public class ProductsController : Controller
	{
		private readonly ApplicationDbContext _db;
		public ProductsController(ApplicationDbContext db) => _db = db;

		// READ: lista produkter (med valfri filtrering via ?category=...)
		public async Task<IActionResult> Index(string? category)
		{
			var query = _db.Products.Include(p => p.Category).AsQueryable();

			if (!string.IsNullOrWhiteSpace(category))
			{
				query = query.Where(p => p.Category != null && p.Category.Name == category);
				ViewBag.CategoryName = category; // för rubrik i vyn
			}

			var products = await query
				.OrderBy(p => p.Category!.Name)
				.ThenBy(p => p.Name)
				.ToListAsync();

			return View(products);
		}

		// CREATE (GET): visa formulär
		public IActionResult Create()
		{
			ViewBag.Categories = _db.Categories
									.OrderBy(c => c.Name)
									.ToList();
			return View();
		}

		// CREATE (POST): spara från formulär
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Product product)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.Categories = _db.Categories.OrderBy(c => c.Name).ToList();
				return View(product);
			}

			_db.Products.Add(product);
			await _db.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}
