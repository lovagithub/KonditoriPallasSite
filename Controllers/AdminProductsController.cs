using KonditoriPallasSite.Data;
using KonditoriPallasSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KonditoriPallasSite.Controllers
{
	[Authorize] // kräver inloggning
	public class AdminProductsController : Controller
	{
		private readonly ApplicationDbContext _db;
		public AdminProductsController(ApplicationDbContext db) => _db = db;

		// GET: /AdminProducts
		public async Task<IActionResult> Index()
		{
			var products = await _db.Products
				.Include(p => p.Category)
				.OrderBy(p => p.Name)
				.ToListAsync();
			return View(products);
		}

		// GET: /AdminProducts/Create
		public async Task<IActionResult> Create()
		{
			ViewBag.Categories = await _db.Categories
				.OrderBy(c => c.Name).ToListAsync();
			return View(new Product());
		}

		// POST: /AdminProducts/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Product model)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.Categories = await _db.Categories.OrderBy(c => c.Name).ToListAsync();
				return View(model);
			}

			_db.Products.Add(model);
			await _db.SaveChangesAsync();
			TempData["Ok"] = $"Produkten “{model.Name}” lades till.";
			return RedirectToAction(nameof(Index));
		}

		// GET: /AdminProducts/Delete/{id}
		public async Task<IActionResult> Delete(int id)
		{
			var product = await _db.Products
				.Include(p => p.Category)
				.FirstOrDefaultAsync(p => p.Id == id);

			if (product == null) return NotFound();
			return View(product);
		}

		// POST: /AdminProducts/Delete/{id}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var product = await _db.Products.FindAsync(id);
			if (product == null) return NotFound();

			_db.Products.Remove(product);
			await _db.SaveChangesAsync();
			TempData["Ok"] = $"Produkten “{product.Name}” togs bort.";
			return RedirectToAction(nameof(Index));
		}
	}
}
