﻿using API.Contracts;
using API.DTOs.Accounts;
using API.Models;
using API.Repositories;
using API.Utilities.Handlers.Exceptions;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using API.DTOs.Employees;
using API.DTOs.Leaves;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILeaveRepository _leaveRepository;

        public ManagerController(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository, ILeaveRepository leaveRepository)
        {

            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
            _leaveRepository = leaveRepository;
        }

        [HttpGet("Staffs/{guid}")]
        public IActionResult GetStaffs(Guid guid)
        {
            var employees = _employeeRepository.GetAll();
            var department = _departmentRepository.GetDepartmentByManagerGuid(guid);
            if (!employees.Any() || department == null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var staffs = employees.Where(e => e.DepartmentGuid == department.Guid).Select(s => EmployeeDetailsDto.ConvertToStaffDetails(s, department));
            return Ok(new ResponseOkHandler<IEnumerable<EmployeeDetailsDto>>(staffs));
        }

        [HttpPut("Staffs/Edit")]
        public IActionResult EditStaff()
        {
            return BadRequest();
        }


        [HttpGet("Leaves/Pending/{guid}")]
        public IActionResult GetPendingLeaves(Guid guid)
        {
            var employees = _employeeRepository.GetAll();
            var leaves = _leaveRepository.GetAll();
            var departments = _departmentRepository.GetAll();
            var department = _departmentRepository.GetDepartmentByManagerGuid(guid) ?? throw new Exception("department manager not found");
            if (!leaves.Any() && !employees.Any() && !departments.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leavess = from emp in employees
                          join l in leaves on emp.Guid equals l.EmployeeGuid
                          join d in departments on emp.DepartmentGuid equals department.Guid
                          select new LeaveDto
                          {
                              StartDate = l.StartDate,
                              EndDate = l.EndDate,
                              Description = l.Description,
                              Status = l.Status.ToString(),
                              RemarksManager = l.RemarksManager,
                              RemarksHR = l.RemarksHR
                          };

            var approvedLeaves = leavess.Where(l => l.Status == "Pending");
            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(approvedLeaves));

        }
        [HttpGet("Leaves/Rejected/{guid}")]
        public IActionResult GetRejectedLeaves(Guid guid)
        {
            var employees = _employeeRepository.GetAll();
            var leaves = _leaveRepository.GetAll();
            var departments = _departmentRepository.GetAll();
            var department = _departmentRepository.GetDepartmentByManagerGuid(guid) ?? throw new Exception("department manager not found");
            if (!leaves.Any() && !employees.Any() && !departments.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leavess = from emp in employees
                          join l in leaves on emp.Guid equals l.EmployeeGuid
                          join d in departments on emp.DepartmentGuid equals department.Guid
                          select new LeaveDto
                          {
                              StartDate = l.StartDate,
                              EndDate = l.EndDate,
                              Description = l.Description,
                              Status = l.Status.ToString(),
                              RemarksManager = l.RemarksManager,
                              RemarksHR = l.RemarksHR
                          };

            var approvedLeaves = leavess.Where(l => l.Status == "Rejected");
            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(approvedLeaves));
        }
        [HttpGet("Leaves/Approved/{guid}")]
        public IActionResult GetApprovedLeaves(Guid guid)
        {
            var employees = _employeeRepository.GetAll();
            var leaves = _leaveRepository.GetAll();
            var departments = _departmentRepository.GetAll();
            var department = _departmentRepository.GetDepartmentByManagerGuid(guid) ?? throw new Exception("department manager not found");
            if (!leaves.Any() && !employees.Any() && !departments.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leavess = from emp in employees
                                 join l in leaves on emp.Guid equals l.EmployeeGuid
                                 join d in departments on emp.DepartmentGuid equals department.Guid
                                 select new LeaveDto
                                 {
                                     StartDate = l.StartDate,
                                     EndDate = l.EndDate,
                                     Description = l.Description,
                                     Status = l.Status.ToString(),
                                     RemarksManager = l.RemarksManager,
                                     RemarksHR = l.RemarksHR
                                 };

            var approvedLeaves = leavess.Where(l => l.Status == "Approved");
            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(approvedLeaves));
        }


        [HttpPut("Leaves/Edit")]
        public IActionResult EditLeave(EditLeaveDto editLeaveDto)
        {
            try
            {
                var entity = _leaveRepository.GetByGuid(editLeaveDto.Guid);
                if (entity is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                }
                entity = EditLeaveDto.EditLeaveByManager(editLeaveDto, entity);

                var result = _leaveRepository.Update(entity);
                return Ok(new ResponseOkHandler<String>("Data Updated"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Update Data", e.Message));
            }
        }
    }
}
