using KonditoriPallasSite.Data;
using KonditoriPallasSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace KonditoriPallasSite.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationDbContext _db;
		public HomeController(ApplicationDbContext db) => _db = db;

		// STARTSIDA
		public IActionResult Index() => View();

		// OM OSS
		public IActionResult About() => View();

		// LUNCH
		public IActionResult Lunch() => View();

		// KONTAKT (GET) – visar formuläret med modell
		[HttpGet]
		public IActionResult Contact()
		{
			return View(new ContactMessage());
		}

		// KONTAKT (POST) – tar emot och sparar
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Contact(ContactMessage model)
		{
			if (!ModelState.IsValid)
				return View(model);

			_db.ContactMessages.Add(model);
			await _db.SaveChangesAsync();

			TempData["Ok"] = "Tack! Ditt meddelande har skickats. Vi hör av oss inom kort.";
			return RedirectToAction(nameof(Contact));
		}
	}
}
