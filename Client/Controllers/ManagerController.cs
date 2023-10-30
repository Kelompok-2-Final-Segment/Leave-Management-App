using Client.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.DTOs.Managers;
using System;
using API.DTOs.Leaves;
using Client.Models;

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
    public async Task<IActionResult> ManagePendingLeaves(Guid guid)
    {
        var result = await _managerRepository.GetPendingLeaves(guid);
        var leaveDetails = result.Data;
       
        if (leaveDetails is null )
        {
            leaveDetails = new List<LeaveDto>();
        }

        return View("pending-leave",leaveDetails);
    }

    [HttpGet("leaves/pending/edit")]
    public async Task<IActionResult> ManageLeave(Guid guid)
    {
        var result = await _managerRepository.GetLeaveDetails(guid);
        var leaveDetails = result.Data;

        if (leaveDetails is null)
        {
            leaveDetails = new LeaveDetailManagerDto();
        }
        var CombinedEmployeeLeave = new EditStatusManagerModel { EmployeeDetail = leaveDetails };
        return View("pending-leave-edit", CombinedEmployeeLeave);
    }

    [HttpPost("leaves/pending/edit")]
    public async Task<IActionResult> ManageLeave(EditStatusManagerModel editStatusManagerModel)
    {
        var result = await _managerRepository.EditLeave(editStatusManagerModel.EditLeave);

        if (result.Status == "OK")
        {
            RedirectToAction("ManagePendingLeaves", new { guid = editStatusManagerModel.EmployeeDetail.EmployeeGuid });
        }
        
        return View("pending-leave", new { guid = editStatusManagerModel.EmployeeDetail.EmployeeGuid });
    }

    [HttpGet("leaves/approved")]
    public async Task<IActionResult> ManageApprovedLeaves()
    {
        return View("approved-leave");
    }

    [HttpGet("leaves/rejected")]
    public async Task<IActionResult> ManageRejectedLeaves()
    {
        return View("rejected-leave");
    }

    [HttpGet("leaves/history")]

    public async Task<IActionResult> ManageLeaveHistories()
    {
        return View("leave-history");
    }

    [HttpGet("leaves/statistic")]

    public async Task<IActionResult> ManageLeaveStatistics()
    {
        return View("leave-statistic");
    }


    // Employeee Management
    [HttpGet("staff/")]
    public async Task<IActionResult> GetAllEmployee()
    {
        return View("employee");
    }
}
