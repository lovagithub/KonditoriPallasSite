using KonditoriPallasSite.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
var builder = WebApplication.CreateBuilder(args);



// MVC
builder.Services.AddControllersWithViews();

// EF Core – koppla din DbContext till connection string "DefaultConnection" i appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Cookie-autentisering (används för din UserController-inloggning)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(o =>
	{
		o.LoginPath = "/User/Index";      // inloggningssida
		o.AccessDeniedPath = "/User/Index";
		// o.LogoutPath = "/User/Logout"; // bara om du vill att /User/Logout ska trigga SignOut automatiskt
	});

var app = builder.Build();

// (valfritt) Produktion: snygg felhantering + HSTS
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();   // Viktigt: före Authorization
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

// --- Seed: skapa/uppdatera DB och fyll med exempeldata vid uppstart ---
using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
	context.Database.Migrate();      // skapar DB och kör pending migrations
	SeedData.Initialize(context);    // fyller med demo-data om tomt
}

app.Run();
