using API.DTOs.Accounts;
using API.DTOs.LeaveTypes;
using API.Models;
using API.Utilities.Handlers;
using API.Utilities.Handlers.Exceptions;
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
    private readonly ILeaveTypeRepository leaveTypeRepository;

    public AdminController(IAdminRepository adminRepository, ILeaveTypeRepository leaveTypeRepository)
    {
        this.adminRepository = adminRepository;
        this.leaveTypeRepository = leaveTypeRepository;
    }

    // Main Admin Dashboard
    public IActionResult Index()
    {
        return View();
    }

    // Get All Leave in JSON
    [HttpGet("/admin/leave/all")]
    public async Task<IActionResult> GetAllLeave()
    {
        var result = await adminRepository.GetAllLeave();

        if (result == null)
        {
            return NotFound();
        }

        return Json(result);
    }

    [HttpGet("/admin/leave/pending")]
    public IActionResult PendingLeave()
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

    [HttpGet("admin/leave/type/all")]
    public async Task<IActionResult> GetAllLeaveType()
    {
        var result = await leaveTypeRepository.GetAll();

        if (result == null)
        {
            return Json(NotFound());
        }

        return Json(result);
    }

    [HttpDelete("admin/leave/type/delete/{guid}")]
    public async Task<IActionResult> DeleteLeaveType(Guid guid)
    {
        var result = await leaveTypeRepository.Delete(guid);

        return Json(result);
    }

    [HttpPost("admin/leave/type/create")]
    public async Task<IActionResult> CreateLeaveType(string entity)
    {
        Debug.WriteLine("Cek disini");
        Debug.WriteLine(entity);
        try
        {
            var createData = JsonConvert.DeserializeObject<CreateLeaveTypeDto>(entity);

            var result = await leaveTypeRepository.Create(createData);

            return Json(result);

        }
        catch
        {
            var errorResponse = new ResponseBadRequestHandler("Input Data must not be null");

            return Json(errorResponse);
        }
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

    [HttpPost("admin/employee/new")]
    public async Task<IActionResult> CreateEmployee(string entity)
    {
        Debug.WriteLine("Cek disini");
        Debug.WriteLine(entity);
        try
        {
            RegisterDto registerData = JsonConvert.DeserializeObject<RegisterDto>(entity);

            var result = await adminRepository.RegisterEmployee(registerData);

            return Json(result);

        }
        catch
        {
            var errorResponse = new ResponseBadRequestHandler("Input Data must not be null");

            return Json(errorResponse);
        }
    }

    [HttpGet("/admin/employee/detail")]
    public IActionResult GetEmployeeDetail()
    {
        return RedirectToAction("Employee");
    }

    [HttpDelete("admin/employee/delete/{guid}")]
    public async Task<IActionResult> DeleteEmployee(string guid)
    {
        try
        {
            Guid employeeGuid = Guid.Parse(guid);

            var result = await adminRepository.DeleteEmployee(employeeGuid);

            return Json(result);
        }
        catch
        {
            var errorResponse = new ResponseBadRequestHandler("ID is Invalid or Not Found");

            return Json(errorResponse);
        }
    }

    [HttpPost("admin/employee/detail")]
    public async Task<IActionResult> EmployeeDetail(string guid)
    {
        try
        {
            Guid employeeGuid = Guid.Parse(guid);
            Debug.WriteLine("Cek disini");
            Debug.WriteLine(guid);
            var result = await adminRepository.GetEmployeeByGuid(employeeGuid);

            EmployeeCombinedModel model = new EmployeeCombinedModel();
            model.EmployeeDetail = result.Data;

            Debug.WriteLine("Cek disini");
            Debug.WriteLine(model.EmployeeDetail.FullName);

            return View("employee-detail", model);
        }
        catch
        {
            return NotFound();
        }
    }
}
