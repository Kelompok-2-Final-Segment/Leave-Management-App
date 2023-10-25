using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class AdminController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    // Auth
    [HttpGet("/admin/login")]
    public IActionResult Login()
    {
        return View("login");
    }

    [HttpGet("/admin/logout")]
    public IActionResult Logout()
    {
        return View();
    }

    // Leaves Management
    [HttpGet("/admin/leave/pending")]
    public IActionResult ManagePendingLeaves()
    {
        return View("pending-leaves");
    }

    [HttpGet("/admin/leave/approved")]
    public IActionResult ManageApprovedLeaves()
    {
        return View("approved-leaves");
    }

    [HttpGet("admin/leave/rejected")]
    public IActionResult ManageRejectedLeaves()
    {
        return View("rejected-leaves");
    }

    [HttpGet("admin/leave/type")]
    public IActionResult ManageLeaveTypes()
    {
        return View("leave-type");
    }

    [HttpGet("admin/leave/history")]

    public IActionResult ManageLeaveHistory()
    {
        return View("leave-history");
    }

    [HttpGet("admin/leave/statistic")]

    public IActionResult ManageLeaveStatistic()
    {
        return View("leave-statistic");
    }


    // Employeee Management 
    [HttpGet("admin/employee/")]
    public IActionResult GetAllEmployee()
    {
        return View("employee");
    }

    [HttpPost]
    public IActionResult CreateEmployee()
    {
        return View();
    }


}
