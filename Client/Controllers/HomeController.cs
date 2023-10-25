using Client_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client_API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Auth
        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View("login");
        }

        [HttpGet("/logout")]
        public IActionResult Logout()
        {
            return View("logout");
        }

        [AllowAnonymous]
        [HttpGet("/Unauthorized")]
        public IActionResult Unauthorized()
        {
            return View("401");
        }

        [AllowAnonymous]
        [HttpGet("/NotFound")]
        public IActionResult NotFound()
        {
            return View("404");
        }

        [AllowAnonymous]
        [HttpGet("/Forbidden")]
        public IActionResult Forbidden()
        {
            return View("403");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}