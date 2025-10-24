
	using KonditoriPallasSite.Models;
	using Microsoft.AspNetCore.Authentication.Cookies;
	using Microsoft.AspNetCore.Authentication;
	using Microsoft.AspNetCore.Mvc;
	using System.Security.Claims;



namespace KonditoriPallasSite.Controllers

{
	public class UserController : Controller
		{
			public IActionResult Index(string returnUrl = "")
			{
				@ViewData["ReturnUrl"] = returnUrl;
				return View();
			}
			// POST: /User
			[HttpPost]
			public async Task<IActionResult> Index(UserModel userModel, string returnUrl = "")
			{
				// Kolla inloggningen
				bool validUser = CheckUser(userModel);

				if (validUser == true)
				{
					// Allt stämmer, logga in användaren
					var identity = new ClaimsIdentity(
						CookieAuthenticationDefaults.AuthenticationScheme);

					identity.AddClaim(new Claim(ClaimTypes.Name, userModel.UserName));

					await HttpContext.SignInAsync(
						CookieAuthenticationDefaults.AuthenticationScheme,
						new ClaimsPrincipal(identity));
					if (returnUrl != "")
						return Redirect(returnUrl);
					else

						return RedirectToAction("Index", "Home");
				}
				else
				{
					ViewBag.ErrorMessage = "Inloggningen inte godkänd";
					@ViewData["ReturnUrl"] = returnUrl;
					return View();
				}
			}

			// GET: /User/Logout
			[HttpGet]
			public async Task<IActionResult> SignOutUser()
			{
				await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
				return RedirectToAction("Index", "Home");
			}


			private bool CheckUser(UserModel userModel)
			{
				// Hard coded. ToDo: Check in database
				if (userModel.UserName.ToUpper() == "ADMIN" && userModel.Password == "pwd")
					return true;
				else
					return false;
			}
		}
	}
