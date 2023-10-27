using API.Models;
using Client.Contracts;
using Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Client.Controllers;

public class AdminController : Controller
{
    private readonly IAdminRepository adminRepository;

    public AdminController(IAdminRepository adminRepository)
    {
        this.adminRepository = adminRepository;
    }

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
    public async Task<IActionResult> GetAllEmployee()
    {
        var result = await adminRepository.GetAllEmployee();
        
        if (result == null)
        {
            return NotFound();
        }

        return Json(result);
    }

    [HttpPost("admin/employee/create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateEmployee(EmployeeCombinedModel combinedObject)
    {
        Debug.WriteLine("CEK DISINI : ADMIN EMPLOYEE");
        Debug.WriteLine(JsonConvert.SerializeObject(combinedObject.RegisterEmployee));

        var registrationData = combinedObject.RegisterEmployee;
        var result = await adminRepository.RegisterEmployee(registrationData);

        return RedirectToAction("Employee");
    }
}
