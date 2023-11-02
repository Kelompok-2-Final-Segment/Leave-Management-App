using Client.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.DTOs.Managers;
using System;
using API.DTOs.Leaves;
using Client.Models;
using Client.Repositories;

namespace Client.Controllers;

[Route("[controller]/")]
[Authorize(Policy = "Manager")]
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

        return View("pending-leave",leaveDetails.OrderByDescending(l => l.CreatedDate));
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
            TempData["message"] = "Leave Has been Updated Successfully";
            return RedirectToAction("ManagePendingLeaves", new { guid = editStatusManagerModel.EmployeeDetail.ManagerGuid });
        }
        TempData["fail"] = result.Message;
        return RedirectToAction("Index", new { guid = editStatusManagerModel.EmployeeDetail.ManagerGuid });
    }

    [HttpGet("leaves/approved")]
    public IActionResult ManageApprovedLeaves(Guid guid)
    {
        TempData["guid"] = guid;
        return View("approved-leave");
    }

    [HttpGet("leaves/rejected")]
    public IActionResult ManageRejectedLeaves(Guid guid)
    {
        TempData["guid"] = guid;
        return View("rejected-leave");
    }

    [HttpGet("leaves/history")]
    public IActionResult ManageLeaveHistories(Guid guid)
    {
        TempData["guid"] = guid;
        return View("leave-history");
    }

    // GET All Leave Record in JSON
    [HttpGet("Leaves/Histories/{guid}")]
    public async Task<IActionResult> GetAllLeave(Guid guid)
    {
        var result = await _managerRepository.GetHistoryLeaves(guid);

        if (result == null)
        {
            return Json(NotFound());
        }

        return Json(result);
    }

    // GET All Rejected Leave in JSON
    [HttpGet("Leaves/Rejected/{guid}")]
    public async Task<IActionResult> GetRejectedLeave(Guid guid)
    {
        var result = await _managerRepository.GetRejectedLeaves(guid);

        if (result == null)
        {
            return NotFound();
        }

        return Json(result);
    }

    // GET All Rejected Leave in JSON
    [HttpGet("Leaves/Approved/{guid}")]
    public async Task<IActionResult> GetApprovedLeave(Guid guid)
    {
        var result = await _managerRepository.GetApprovedLeaves(guid);

        if (result == null)
        {

            return NotFound();
        }

        return Json(result);
    }
    // GET Leave Type by Guid
    [HttpGet("/leaves/{guid}")]
    public async Task<IActionResult> GetLeaveDetailByGuid(Guid guid)
    {
        var result = await _managerRepository.GetLeaveDetails(guid);
        if (result == null)
        {

            return NotFound();
        }
        return Json(result);
    }


    // Employeee Management
    [HttpGet("Staffs/{guid}")]
    public async Task<IActionResult> GetAllStaffs(Guid guid)
    {
        var result = await _managerRepository.GetStaffs(guid);
        if(result.Status == "OK")
        {
            return View("employee", result.Data);
        }
        return View("employee");
    }
}
