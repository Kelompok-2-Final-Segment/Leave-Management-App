using API.DTOs.Leaves;
using Client.Contracts;
using Client.DTOs;
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
        RequestLeaveDto requestLeaveDto = new RequestLeaveDto { LeaveType = AvailableLeaves , Leave = new CreateLeaveDto { EmployeeGuid = guid } };
        return View(requestLeaveDto);
    }

    [HttpPost]
    public async Task<IActionResult> RequestALeave(RequestLeaveDto requestLeaveDto)
    {
        var result = await _staffRepository.RequestALeave(requestLeaveDto.Leave);
        if(result.Status == "OK")
        {
           return RedirectToAction("Index");
        }
        return View();
    }

    public IActionResult LeaveBalance()
    {
        return View();
    }

    [HttpGet]
    public IActionResult LeaveHistories(Guid guid)
    {
        var result = _staffRepository.GetAvailableLeaves(guid).Result;
        var AvailbleLeaves = result.Data;
        return View(AvailbleLeaves);
    }

}
