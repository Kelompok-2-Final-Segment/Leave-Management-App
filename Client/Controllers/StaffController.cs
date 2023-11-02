using API.DTOs.Leaves;
using API.Models;
using Client.Contracts;
using Client.DTOs;
using Client.Models;
using Client.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Client.Controllers;
public class StaffController : Controller
{
    private readonly IStaffRepository _staffRepository;

    public StaffController(IStaffRepository staffRepository)
    {
        _staffRepository = staffRepository;
    }

    [HttpGet]
    public IActionResult Index(Guid guid)
    {

        var result = _staffRepository.GetAvailableLeaves(guid).Result;
        var AvailbleLeaves = result.Data;
        return View(AvailbleLeaves);
    }

    // Leaves Management
    [HttpGet]
    public IActionResult RequestALeave(Guid guid)
    {
        var result = _staffRepository.GetAvailableLeaves(guid).Result;
        var AvailableLeaves = result.Data;
        if (AvailableLeaves == null)
        {
            return View(new RequestLeaveDto());
        }
        RequestLeaveDto requestLeaveDto = new RequestLeaveDto { LeaveType = AvailableLeaves , Leave = new CreateLeaveDto { EmployeeGuid = guid } };
        return View(requestLeaveDto);
    }

    [HttpPost]
    public async Task<IActionResult> RequestALeave(RequestLeaveDto requestLeaveDto)
    {
        var result = await _staffRepository.RequestALeave(requestLeaveDto.Leave);
        if(result.Code < 300)
        {
            TempData["message"] = "Request Has been Created Successfully";
           return RedirectToAction("Index", new {guid = requestLeaveDto.Leave.EmployeeGuid});
        } else if(result.Code >= 300)
        {
            TempData["reqFail"] = result.Message;
            return RedirectToAction("Index", new { guid = requestLeaveDto.Leave.EmployeeGuid });
        }
        return RedirectToAction("Index", new { guid = requestLeaveDto.Leave.EmployeeGuid });
    }

    [HttpGet]
    public async Task<IActionResult> Profile(Guid guid)
    {
        var result = await _staffRepository.Profile(guid);
        if (result.Status == "OK")
        {
            var EmployeeDto = result.Data;
            return View(EmployeeDto);
        }
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> LeaveHistories(Guid guid)
    {
        var result = await _staffRepository.GetStatisticLeaves(guid);
        ViewBag.EmployeeGuid = guid;
        if (result.Status == "OK")
        {
            var statisticDto = result.Data;
            return View(statisticDto);
        }
        return View();
    }

    [HttpGet("/staffs/leaves/history/{guid}")]
    public async Task<IActionResult> GetLeaveHistories(Guid guid)
    {
        var result = await _staffRepository.GetHistoryLeaves(guid);

        if (result == null)
        {
            return Json(NotFound());
        }

        return Json(result);
    }

    [HttpGet("/staffs/leaves/pending/{guid}")]
    public async Task<IActionResult> GetLeavePending(Guid guid)
    {
        var result = await _staffRepository.GetPendingLeaves(guid);

        if (result == null)
        {
            return Json(NotFound());
        }

        return Json(result);
    }
    [HttpGet]
    public async Task<IActionResult> LeavePending(Guid guid)
    {
        var result = await _staffRepository.GetPendingLeaves(guid);

        if (result.Status == "OK" && result.Data is not null)
        {
            ViewBag.EmployeeGuid = guid;
            return View("LeavePending",result.Data);
        }
        
        return View("LeavePending",result.Data);
    }

    // GET Leave Type by Guid
    [HttpGet("/staff/leave/{guid}")]
    public async Task<IActionResult> GetLeaveDetailByGuid(Guid guid)
    {
        var result = await _staffRepository.GetLeaveDetail(guid);
        if (result == null)
        {
            return NotFound();
        }
        return Json(result);
    }   
    
    [HttpPost("/leave/edit/")]
    public async Task<IActionResult> CancelLeave(CancelLeaveModel cancelLeaveModel)
    {
        var result = await _staffRepository.CancelRequestLeave(cancelLeaveModel.GuidLeave);
        if (result == null)
        {
            return NotFound();
        }
        return Json(new { redirectUrl = Url.Action("LeavePending", new { guid = cancelLeaveModel.GuidEmployee }) });
    }

}
