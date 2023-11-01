using Client.Contracts;
using API.DTOs.Accounts;
using Client_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Client_API.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public HomeController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
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
        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _accountRepository.Login(loginDto);
            if (result.Status == "OK")
            {
                HttpContext.Session.SetString("JWToken", result.Data.Token);
                var claimsResponse = await _accountRepository.GetClaims(result.Data.Token);
                if (claimsResponse.Status == "OK" && claimsResponse.Data != null)
                {
                    var role = (claimsResponse.Data.Role[0]);
                    var identifier = claimsResponse.Data.NameIdentifier;
                    if (role == "Staff")
                    {
                        return RedirectToAction("Index", "Staff", new { guid = identifier });
                    } else if (role == "Manager")
                    {
                        return RedirectToAction("Index", "Manager", new {guid = identifier });
                    } else if (role == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                }
               
            }
           
            return View("login");
        }

        [HttpGet("/forgotpassword")]
        public IActionResult ForgotPassword()
        {
            return View("forgotpassword");
        }

        [HttpPost("/forgotpassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            return View("forgotpassword");
        }

        [HttpPost("/changepassword")]
        public IActionResult ChangePassword()
        {
            return View("changepassword");
        }

        [HttpGet("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
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