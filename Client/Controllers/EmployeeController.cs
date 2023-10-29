using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class EmployeeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    // Leaves Management
    public IActionResult RequestLeave()
    {
        return View();
    }

    public IActionResult LeaveBalance()
    {
        return View();
    }

    public IActionResult LeaveHistories()
    {
        return View();
    }

}
