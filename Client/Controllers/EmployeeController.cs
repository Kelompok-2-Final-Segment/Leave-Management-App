using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class EmployeeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    // Auth
    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Logout()
    {
        return View();
    }

    // Leaves Management
    public IActionResult RequestLeave()
    {
        return View();
    }

    public IActionResult SeeOnRequestLeave()
    {
        return View();
    }

    public IActionResult ManageLeaveHistories()
    {
        return View();
    }

}
