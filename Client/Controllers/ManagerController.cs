using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers;

public class ManagerController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    // Leaves Management
    [HttpGet("/manager/leave/pending")]
    public IActionResult ManagePendingLeaves()
    {
        return View("pending-leave");
    }

    [HttpGet("/manager/leave/approved")]
    public IActionResult ManageApprovedLeaves()
    {
        return View("approved-leave");
    }

    [HttpGet("manager/leave/rejected")]
    public IActionResult ManageRejectedLeaves()
    {
        return View("rejected-leave");
    }

    [HttpGet("manager/leave/history")]

    public IActionResult ManageLeaveHistory()
    {
        return View("leave-history");
    }

    [HttpGet("manager/leave/statistic")]

    public IActionResult ManageLeaveStatistic()
    {
        return View("leave-statistic");
    }


    // Employeee Management
    [HttpGet("manager/staff/")]
    public IActionResult GetAllEmployee()
    {
        return View("employee");
    }
}
