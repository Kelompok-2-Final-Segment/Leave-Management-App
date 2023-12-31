﻿using API.DTOs.Accounts;
using API.DTOs.Employees;
using API.DTOs.Leaves;
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

[Authorize(Policy = "Admin")]
public class AdminController : Controller
{
    private readonly IAdminRepository adminRepository;
    private readonly ILeaveTypeRepository leaveTypeRepository;

    public AdminController(IAdminRepository adminRepository, ILeaveTypeRepository leaveTypeRepository)
    {
        this.adminRepository = adminRepository;
        this.leaveTypeRepository = leaveTypeRepository;
    }

    /*
     * MAIN DASHBOARD ACTION */
    public async Task<IActionResult> Index()
    {
        AdminDashboardModels models = new AdminDashboardModels();
        var getStatistics = await adminRepository.GetStatistic();
        var getAllLeave = await adminRepository.GetAllLeave();
        var getAllDepartment = await adminRepository.GetAllDepartment();
        var getAllEmployee = await adminRepository.GetAllEmployee();

        var employees = getAllEmployee.Data;
        var departments = getAllDepartment.Data;
        var departmentDetails = from department in departments
                                join employee in employees on department.ManagerGuid equals employee.Guid
                                select new DepartmentManager
                                {
                                    Guid = department.Guid,
                                    Name = department.Name,
                                    Manager = string.Concat(employee.FirstName+ " "+ employee.LastName) 
                                };

        models.Statistic = getStatistics.Data;
        models.LeaveHistory = getAllLeave.Data;
        models.DepartmentManagers = departmentDetails.ToList();
        
        if(models.LeaveHistory != null)
        {
            models.LeaveHistory = models.LeaveHistory.OrderByDescending(item => item.CreatedDate);
            models.LeaveHistory = models.LeaveHistory.Take(7);
        }

        return View(models);
    }



    /* 
     * LEAVE RECORDS ACTIONS */

    // PAGE : Return Pending Leave Page
    [HttpGet("/admin/leave/pending")]
    public IActionResult PendingLeave()
    {
        return View("pending-leave");
    }

    // PAGE : Return Approved Leave Page
    [HttpGet("/admin/leave/approved")]
    public IActionResult ManageApprovedLeaves()
    {
        return View("approved-leave");
    }

    // PAGE : Return Rejected Leave Page
    [HttpGet("admin/leave/rejected")]
    public IActionResult ManageRejectedLeaves()
    {
        return View("rejected-leave");
    }

    // PAGE : Return Pending Leave Page
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

    // GET All Leave Record in JSON
    [HttpGet("/admin/leave/all")]
    public async Task<IActionResult> GetAllLeave()
    {
        var result = await adminRepository.GetAllLeave();

        if (result == null)
        {
            return Json(NotFound());
        }
        
        result.Data = result.Data.OrderByDescending(item => item.CreatedDate);

        return Json(result);
    }

    // GET All Rejected Leave in JSON
    [HttpGet("/admin/leave/rejected/all")]
    public async Task<IActionResult> GetRejectedLeave()
    {
        var result = await adminRepository.GetRejectedLeave();

        if (result == null)
        {
            return NotFound();
        }

        result.Data = result.Data.OrderByDescending(item => item.CreatedDate);


        return Json(result);
    }

    // GET All Rejected Leave in JSON
    [HttpGet("/admin/leave/approved/all")]
    public async Task<IActionResult> GetApprovedLeave()
    {
        var result = await adminRepository.GetApprovedLeave();

        if (result == null)
        {

            return NotFound();
        }

        result.Data = result.Data.OrderByDescending(item => item.CreatedDate);

        return Json(result);
    }

    // GET All Pending Leave in JSON
    [HttpGet("/admin/leave/pending/all")]
    public async Task<IActionResult> GetPendingLeave()
    {
        var result = await adminRepository.GetPendingLeave();

        if (result == null)
        {
            string[] emptyArray = { };
            var emptyResponse = new ResponseOkHandler<string[]>(emptyArray);
            return Json(emptyResponse);
        }

        result.Data = result.Data.OrderByDescending(item => item.CreatedDate);

        return Json(result);
    }

    // GET Leave Type by Guid
    [HttpGet("admin/leave/{guid}")]
    public async Task<IActionResult> GetLeaveDetailByGuid(Guid guid)
    {
        var result = await adminRepository.GetLeaveDetail(guid);

        return Json(result);
    }

    // PUT or Update Leave Status
    [HttpPut("admin/leave/update/")]
    public async Task<IActionResult> UpdateLeaveStatus(string entity)
    {
        Debug.WriteLine("Cek disini");
        Debug.WriteLine(entity);
        try
        {
            var updateData = JsonConvert.DeserializeObject<EditLeaveDto>(entity);

            var result = await adminRepository.UpdateLeaveStatus(updateData);

            return Json(result);

        }
        catch
        {
            var errorResponse = new ResponseBadRequestHandler("Input Data must not be empty");

            return Json(errorResponse);
        }
    }


    /*
     * LEAVE TYPE ACTIONS */

    // Return Leave Type Page HTML
    [HttpGet("admin/leave-type/")]
    public IActionResult PageLeaveType()
    {
        return View("leave-type");
    }

    // POST or Create New Leave Type
    [HttpPost("admin/leave-type/create")]
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

    // GET All Leave Type
    [HttpGet("admin/leave-type/all")]
    public async Task<IActionResult> GetAllLeaveType()
    {
        var result = await leaveTypeRepository.GetAll();

        if (result == null)
        {
            return Json(NotFound());
        }

        return Json(result);
    }

    // GET Leave Type by Guid
    [HttpGet("admin/leave-type/{guid}")]
    public async Task<IActionResult> GetLeaveTypeByGuid(Guid guid)
    {
        var result = await leaveTypeRepository.GetByGuid(guid);

        return Json(result);
    }

    // DELETE Leave Type by Guid
    [HttpDelete("admin/leave-type/delete/{guid}")]
    public async Task<IActionResult> DeleteLeaveType(Guid guid)
    {
        var result = await leaveTypeRepository.Delete(guid);

        return Json(result);
    }

    // PUT or Update Leave Type
    [HttpPut("admin/leave-type/update/")]
    public async Task<IActionResult> UpdateLeaveType(string entity)
    {
        Debug.WriteLine("Cek disini");
        Debug.WriteLine(entity);
        try
        {
            var updateData = JsonConvert.DeserializeObject<LeaveTypeDto>(entity);

            var result = await leaveTypeRepository.Update(updateData);

            return Json(result);

        }
        catch
        {
            var errorResponse = new ResponseBadRequestHandler("Input Data must not be null");

            return Json(errorResponse);
        }
    }

    
    /*
     * EMPLOYEE ACTIONS */

    // PAGE : Return Employee Page
    [HttpGet("admin/employee/")] 
    public async Task<IActionResult> Employee()
    {
        var getStatistics = await adminRepository.GetStatistic();

        var models = new AdminDashboardModels();
        models.Statistic = getStatistics.Data;

        return View("employee", models);
    }

    // PAGE : Return to Employee Page
    [HttpGet("/admin/employee/detail")]
    public IActionResult GetEmployeeDetail()
    {
        return RedirectToAction("Employee");
    }
    // PAGE : Return Employee Detail Page
    [HttpPost("admin/employee/detail")]
    public async Task<IActionResult> EmployeeDetail(string guid)
    {
        try
        {
            Guid employeeGuid = Guid.Parse(guid);
            Debug.WriteLine("Cek disini");
            Debug.WriteLine(guid);
            var getEmployeeDetail = await adminRepository.GetEmployeeByGuid(employeeGuid);
            var getEmployeeLeave = await adminRepository.GetAllLeave();
            var getDepartment = await adminRepository.GetAllDepartment();

            AdminDashboardModels model = new AdminDashboardModels();
            model.EmployeeDetail = getEmployeeDetail.Data;
            model.LeaveHistory = getEmployeeLeave.Data;
            model.Departments = getDepartment.Data;
            
            if(model.LeaveHistory != null)
            {
                model.LeaveHistory = model.LeaveHistory.Where(item => item.NIK == model.EmployeeDetail.NIK);
            }
            

            return View("employee-detail", model);
        }
        catch
        {
            return NotFound();
        }
    }

    // PUT or Update Employee 
    [HttpPut("admin/employee/update/")]
    public async Task<IActionResult> UpdateEmployee(string entity)
    {
        Debug.WriteLine("Cek disini");
        Debug.WriteLine(entity);
        try
        {
            var updateData = JsonConvert.DeserializeObject<EditEmployeeDto>(entity);

            var result = await adminRepository.UpdateEmployee(updateData);

            return Json(result);

        }
        catch
        {
            var errorResponse = new ResponseBadRequestHandler("Input Data must not be null");

            return Json(errorResponse);
        }
    }

    // POST or Create New Employee
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

    // GET All Employee Data
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

    // DELETE Employee Data by Guid
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

    [HttpGet("admin/department/all")]
    public async Task<IActionResult> GetAllDepartment()
    {
        var result = await adminRepository.GetAllDepartment();

        if (result == null)
        {
            return NotFound();
        }

        return Json(result);
    }


}
