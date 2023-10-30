using API.Contracts;
using API.DTOs.Accounts;
using API.Models;
using API.Repositories;
using API.Utilities.Handlers.Exceptions;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using API.DTOs.Employees;
using API.DTOs.Leaves;
using API.DTOs.Managers;

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

        [HttpGet("Staffs/All/{guid}")]
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

        [HttpGet("Staffs/{guid}")]
        public IActionResult GetStaff(Guid guid)
        {
            var employee = _employeeRepository.GetByGuid(guid);
            if (employee is null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var department = _departmentRepository.GetByGuid(employee.DepartmentGuid);
            if (department == null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var staff = EmployeeDetailsDto.ConvertToStaffDetails(employee, department);
            return Ok(new ResponseOkHandler<EmployeeDetailsDto>(staff));
        }

        [HttpPut("Staffs/Edit")]
        public IActionResult EditStaff()
        {
            return BadRequest();
        }

        [HttpGet("Dashboard/{guid}")]
        public IActionResult GetDashboardDetail(Guid guid)
        {
            var leaves = _leaveRepository.GetAll();
            var employees = _employeeRepository.GetAll();
            var leaveTypes = _leaveTypeRepository.GetAll();
            if(!leaves.Any() && !employees.Any() && !leaveTypes.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var department = _departmentRepository.GetDepartmentByManagerGuid(guid);
            if (department == null)
            {
                return NotFound(new ResponseNotFoundHandler("Manager not found"));
            }
            var leaveCount = leaves.Count(l => employees.Any(e => e.Guid == l.EmployeeGuid && e.DepartmentGuid == department.Guid));
            var employeeCount = employees.Count(e => e.DepartmentGuid == department.Guid);
            var pendingLeaveCount = leaves.Count(l => l.Status.ToString() == "Pending" && employees.Any(e => e.Guid == l.EmployeeGuid && e.DepartmentGuid == department.Guid));
            var recentLeave = (from l in leaves
                               join lt in leaveTypes on l.LeaveTypeGuid equals lt.Guid
                               join e in employees on l.EmployeeGuid equals e.Guid
                               where e.DepartmentGuid == department.Guid
                               orderby l.CreatedDate descending
                               select LeaveDto.ConvertToLeaveDto(l, lt, e)).Take(10);
            var dashboardManagerDto = DashboardManagerDto.ConvertToDashboardManagerDto(leaveCount, employeeCount, pendingLeaveCount , department,recentLeave);

            return Ok(new ResponseOkHandler<DashboardManagerDto>(dashboardManagerDto));
        }
        [HttpGet("Leaves/Details/{guid}")]
        public IActionResult GetLeaveDetails(Guid guid)
        {
            var leave = _leaveRepository.GetByGuid(guid);
            if (leave == null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leaveType = _leaveTypeRepository.GetByGuid(leave.LeaveTypeGuid);
            var employee = _employeeRepository.GetByGuid(leave.EmployeeGuid);
            if (employee == null || leaveType == null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var department = _departmentRepository.GetByGuid(employee.DepartmentGuid);
            if (department == null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leaveDetailManagerDto = LeaveDetailManagerDto.ConvertToLeaveDetailManagerDto(leave, leaveType, department, employee);


            return Ok(new ResponseOkHandler<LeaveDetailManagerDto>(leaveDetailManagerDto));

        }

        [HttpGet("Leaves/Histories/{guid}")]
        public IActionResult GetHistoryLeaves(Guid guid)
        {
            var employees = _employeeRepository.GetAll();
            var leaves = _leaveRepository.GetAll();
            var leaveTypes = _leaveTypeRepository.GetAll();
            var department = _departmentRepository.GetDepartmentByManagerGuid(guid);
            if (department is null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            if (!leaves.Any() && !leaveTypes.Any() && !employees.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leaveDto = from l in leaves
                           join emp in employees on l.EmployeeGuid equals emp.Guid
                           where emp.DepartmentGuid == department.Guid
                           join lt in leaveTypes on l.LeaveTypeGuid equals lt.Guid
                           select LeaveDto.ConvertToLeaveDto(l, lt, emp);

            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(leaveDto));
        }


        [HttpGet("Leaves/Pending/{guid}")]
        public IActionResult GetPendingLeaves(Guid guid)
        {
            var employees = _employeeRepository.GetAll();
            var leaves = _leaveRepository.GetAll();
            var leaveTypes = _leaveTypeRepository.GetAll();
            var department = _departmentRepository.GetDepartmentByManagerGuid(guid);
            if (department is null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            if (!leaves.Any() && !leaveTypes.Any() && !employees.Any() )
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leaveDto = from l in leaves
                           where l.Status.ToString() == "Pending"
                           join emp in employees on l.EmployeeGuid equals emp.Guid 
                           where emp.DepartmentGuid == department.Guid
                          join lt in leaveTypes on l.LeaveTypeGuid equals lt.Guid
                          select LeaveDto.ConvertToLeaveDto(l, lt, emp);

            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(leaveDto));

        }
        [HttpGet("Leaves/Rejected/{guid}")]
        public IActionResult GetRejectedLeaves(Guid guid)
        {
            var employees = _employeeRepository.GetAll();
            var leaves = _leaveRepository.GetAll();
            var leaveTypes = _leaveTypeRepository.GetAll();
            var department = _departmentRepository.GetDepartmentByManagerGuid(guid);
            if (department is null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            if (!leaves.Any() && !leaveTypes.Any() && !employees.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leaveDto = from l in leaves
                           where l.Status.ToString() == "Rejected"
                           join emp in employees on l.EmployeeGuid equals emp.Guid
                           where emp.DepartmentGuid == department.Guid
                           join lt in leaveTypes on l.LeaveTypeGuid equals lt.Guid
                           select LeaveDto.ConvertToLeaveDto(l, lt, emp);

            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(leaveDto));
        }
        [HttpGet("Leaves/Approved/{guid}")]
        public IActionResult GetApprovedLeaves(Guid guid)
        {
            var employees = _employeeRepository.GetAll();
            var leaves = _leaveRepository.GetAll();
            var leaveTypes = _leaveTypeRepository.GetAll();
            var department = _departmentRepository.GetDepartmentByManagerGuid(guid);
            if (department is null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            if (!leaves.Any() && !leaveTypes.Any() && !employees.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leaveDto = from l in leaves
                           where l.Status.ToString() == "Approved"
                           join emp in employees on l.EmployeeGuid equals emp.Guid
                           where emp.DepartmentGuid == department.Guid
                           join lt in leaveTypes on l.LeaveTypeGuid equals lt.Guid
                           select LeaveDto.ConvertToLeaveDto(l, lt, emp);

            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(leaveDto));
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
