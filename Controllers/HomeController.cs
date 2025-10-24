using Microsoft.AspNetCore.Mvc;

namespace KonditoriPallasSite.Controllers
{
	public class HomeController : Controller
	{
		// Startsidans action
		public IActionResult Index()
		{
			return View();
		}

		// Exempel på extra sidor (frivilligt)
		public IActionResult About()
		{
			return View();
		}

		public IActionResult Contact()
		{
			return View();
		}

		public IActionResult Lunch()
		{
			return View();
		}
	}
}
