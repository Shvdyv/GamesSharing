using EF_Initializer.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using GameSharing.Repository;
using NetAuthService;

namespace EF_Initializer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Database _context;

        //public HomeController(ILogger<HomeController> logger, Database context)
        //{
        //    _logger = logger;
        //    _context = context;
        //}

        public IActionResult Index()
        {
            if (!_context.Users.Any())
            {
                _context.Roles.Add(new GameSharing.Model.AccountService.Role { Id = Guid.NewGuid(), Name = "Admin" });
                _context.Users.Add(new GameSharing.Model.AccountService.User { Id = Guid.NewGuid(), Name = "Admin", Email = "admin@admin.com", Password = "Admin" });
                _context.SaveChanges();
                _context.UserRoles.Add(new GameSharing.Model.AccountService.UserRole { Id = Guid.NewGuid(), User = _context.Users.First(), Role = _context.Roles.First() });
                _context.SaveChanges();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public async Task<IActionResult> LoginAsync()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(string login, string password)
        {
            AuthService _as = new AuthService(_context);
            var user = _as.Login(login, password);
            if (user == null)
            {
                ViewBag.Alert = "Niepoprawne dane logowania";
                return View();
            }

            var claims = _as.GetClaims(user);
            var principal = new ClaimsPrincipal(claims);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToAction(nameof(Index));
        }
    }
}
