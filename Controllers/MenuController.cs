using Microsoft.AspNetCore.Mvc;

namespace KonditoriPallasSite.Controllers
{
	public class MenuController : Controller
	{
		public IActionResult Tartor()
		{
			return View();
		}

		public IActionResult Bageri()
		{
			return View();
		}

		public IActionResult Lunch()
		{
			return View();
		}
	}
}
