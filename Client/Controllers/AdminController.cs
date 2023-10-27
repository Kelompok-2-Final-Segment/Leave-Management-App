using API.Models;
using Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class AdminController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    // Leaves Management
    [HttpGet("/admin/leave/pending")]
    public IActionResult ManagePendingLeaves()
    {
        return View("pending-leave");
    }

    [HttpGet("/admin/leave/approved")]
    public IActionResult ManageApprovedLeaves()
    {
        return View("approved-leave");
    }

    [HttpGet("admin/leave/rejected")]
    public IActionResult ManageRejectedLeaves()
    {
        return View("rejected-leave");
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
    public IActionResult Employee()
    {
        return View("employee");
    }

    [HttpGet("admin/employee/all")]
    public IActionResult GetAllEmployee()
    {
        return View();
    }

    [HttpPost("admin/employee/create")]
    [ValidateAntiForgeryToken]
    public IActionResult CreateEmployee(EmployeeCombinedModel combinedObject)
    {
        return View();
    }
}
