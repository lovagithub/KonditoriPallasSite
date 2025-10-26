using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KonditoriPallasSite.Controllers
{
	// Denna controller kräver inloggning
	[Authorize]
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			// Visa en adminvy (t.ex. hantera beställningar)
			return View();
		}
	}
}
