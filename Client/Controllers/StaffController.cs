﻿using API.DTOs.Leaves;
using Client.Contracts;
using Client.DTOs;
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
        if(result.Status == "OK")
        {
           return RedirectToAction("Index", new {guid = requestLeaveDto.Leave.EmployeeGuid});
        } else if(result.Code == 400)
        {
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

}
