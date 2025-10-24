using Microsoft.AspNetCore.Mvc;
using KonditoriPallasSite.Data;
using KonditoriPallasSite.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KonditoriPallasSite.Controllers
{
	public class ProductsController : Controller
	{
		private readonly ApplicationDbContext _db;

		// Dependency injection av DbContext
		public ProductsController(ApplicationDbContext db)
		{
			_db = db;
		}

		// READ: lista produkter
		public async Task<IActionResult> Index()
		{
			var products = await _db.Products.Include(p => p.Category).ToListAsync();
			return View(products);
		}

		// CREATE (GET): visa formulär
		public IActionResult Create()
		{
			ViewBag.Categories = _db.Categories; // enklare selektionslista i vyn
			return View();
		}

		// CREATE (POST): spara från formulär
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Product product)
		{
			if (!ModelState.IsValid) return View(product);

			_db.Products.Add(product);
			await _db.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		// Det går fint att implementera Edit/Delete också för extra poäng
	}
}

