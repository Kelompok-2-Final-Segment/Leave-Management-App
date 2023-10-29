using API.Contracts;
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
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public ManagerController(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository, ILeaveRepository leaveRepository, ILeaveTypeRepository leaveTypeRepository)
        {

            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
            _leaveRepository = leaveRepository;
            _leaveTypeRepository = leaveTypeRepository;
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
        [HttpGet("Leaves/Histories/{guid}")]
        public IActionResult GetHistoryLeaves(Guid guid)
        {
            var employees = _employeeRepository.GetAll();
            var leaves = _leaveRepository.GetAll();
            var departments = _departmentRepository.GetAll();
            var leaveTypes = _leaveTypeRepository.GetAll();
            var department = _departmentRepository.GetDepartmentByManagerGuid(guid) ?? throw new Exception("department manager not found");
            if (!leaves.Any() && !leaveTypes.Any() && !employees.Any() && !departments.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leavesDto = from emp in employees
                                      join l in leaves on emp.Guid equals l.EmployeeGuid
                                      join lt in leaveTypes on l.LeaveTypeGuid equals lt.Guid
                                      join d in departments on emp.DepartmentGuid equals department.Guid
                                      select LeaveDto.ConvertToLeaveDto(l, lt, emp);

            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(leavesDto));
        }


        [HttpGet("Leaves/Pending/{guid}")]
        public IActionResult GetPendingLeaves(Guid guid)
        {
            var employees = _employeeRepository.GetAll();
            var leaves = _leaveRepository.GetAll();
            var departments = _departmentRepository.GetAll();
            var leaveTypes = _leaveTypeRepository.GetAll();
            var department = _departmentRepository.GetDepartmentByManagerGuid(guid) ?? throw new Exception("department manager not found");
            if (!leaves.Any() && !leaveTypes.Any() && !employees.Any() && !departments.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leaveDto = from emp in employees
                          join l in leaves on emp.Guid equals l.EmployeeGuid
                          join lt in leaveTypes on l.LeaveTypeGuid equals lt.Guid
                          join d in departments on emp.DepartmentGuid equals department.Guid
                          select LeaveDto.ConvertToLeaveDto(l, lt, emp);

            var pendingLeaves = leaveDto.Where(l => l.Status == "Pending");
            if (!pendingLeaves.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(pendingLeaves));

        }
        [HttpGet("Leaves/Rejected/{guid}")]
        public IActionResult GetRejectedLeaves(Guid guid)
        {
            var employees = _employeeRepository.GetAll();
            var leaves = _leaveRepository.GetAll();
            var departments = _departmentRepository.GetAll();
            var leaveTypes = _leaveTypeRepository.GetAll();
            var department = _departmentRepository.GetDepartmentByManagerGuid(guid) ?? throw new Exception("department manager not found");
            if (!leaves.Any() && !leaveTypes.Any() && !employees.Any() && !departments.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leaveDto = from emp in employees
                                      join l in leaves on emp.Guid equals l.EmployeeGuid
                                      join lt in leaveTypes on l.LeaveTypeGuid equals lt.Guid
                                      join d in departments on emp.DepartmentGuid equals department.Guid
                                      select LeaveDto.ConvertToLeaveDto(l, lt, emp);

            var rejectedLeaves = leaveDto.Where(l => l.Status == "Rejected");
            if (!rejectedLeaves.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(rejectedLeaves));
        }
        [HttpGet("Leaves/Approved/{guid}")]
        public IActionResult GetApprovedLeaves(Guid guid)
        {
            var employees = _employeeRepository.GetAll();
            var leaves = _leaveRepository.GetAll();
            var departments = _departmentRepository.GetAll();
            var leaveTypes = _leaveTypeRepository.GetAll();
            var department = _departmentRepository.GetDepartmentByManagerGuid(guid) ?? throw new Exception("department manager not found");
            if (!leaves.Any() && !leaveTypes.Any() && !employees.Any() && !departments.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leaveDto = from emp in employees
                           join l in leaves on emp.Guid equals l.EmployeeGuid
                           join lt in leaveTypes on l.LeaveTypeGuid equals lt.Guid
                           join d in departments on emp.DepartmentGuid equals department.Guid
                           select LeaveDto.ConvertToLeaveDto(l, lt, emp);

            var approvedLeaves = leaveDto.Where(l => l.Status == "Approved");
            if (!approvedLeaves.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
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
