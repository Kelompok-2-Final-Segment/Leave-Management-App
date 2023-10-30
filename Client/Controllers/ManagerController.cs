using Client.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.DTOs.Managers;
namespace Client.Controllers;

[Route("[controller]/")]
public class ManagerController : Controller
{
    private readonly IManagerRepository _managerRepository;

    public ManagerController(IManagerRepository managerRepository)
    {
        _managerRepository = managerRepository;
    }

    //Dashboard
    public async Task<IActionResult> Index(Guid guid)
    {
        var result = await _managerRepository.GetDashboardDetails(guid);
        var ManagerDashboardDto = result.Data;
        if (result.Data is null)
        {
            ManagerDashboardDto = new DashboardManagerDto();
        }
        return View(ManagerDashboardDto);
    }
    



    // Leaves Management
    [HttpGet("leaves/pending")]
    public IActionResult ManagePendingLeaves()
    {
        return View("pending-leave");
    }

    [HttpGet("leaves/approved")]
    public IActionResult ManageApprovedLeaves()
    {
        return View("approved-leave");
    }

    [HttpGet("leaves/rejected")]
    public IActionResult ManageRejectedLeaves()
    {
        return View("rejected-leave");
    }

    [HttpGet("leaves/history")]

    public IActionResult ManageLeaveHistory()
    {
        return View("leave-history");
    }

    [HttpGet("leaves/statistic")]

    public IActionResult ManageLeaveStatistic()
    {
        return View("leave-statistic");
    }


    // Employeee Management
    [HttpGet("staff/")]
    public IActionResult GetAllEmployee()
    {
        return View("employee");
    }
}
