using KonditoriPallasSite.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KonditoriPallasSite.Controllers
{
	[Authorize]
	public class AdminMessagesController(ApplicationDbContext db) : Controller
	{
		public async Task<IActionResult> Index()
		{
			var list = await db.ContactMessages
				.OrderByDescending(x => x.SubmittedAt)
				.ToListAsync();
			return View(list);
		}

		public async Task<IActionResult> Delete(int id)
		{
			var msg = await db.ContactMessages.FindAsync(id);
			if (msg == null) return NotFound();
			db.ContactMessages.Remove(msg);
			await db.SaveChangesAsync();
			TempData["Ok"] = "Meddelandet togs bort.";
			return RedirectToAction(nameof(Index));
		}
	}
}
