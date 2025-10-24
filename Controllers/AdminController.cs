using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KonditoriPallasSite.Controllers
{
	// Denna controller kräver inloggning
	[Authorize]
	public class AdminController : Controller
	{
		public IActionResult Manage()
		{
			// Visa en adminvy (t.ex. hantera beställningar)
			return View();
		}
	}
}
