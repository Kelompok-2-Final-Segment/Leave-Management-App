using API.DTOs.Leaves;
using API.Models;
using API.Utilities.Handlers.Exceptions;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using API.Contracts;
using System;
using API.DTOs.Employees;
using API.Repositories;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly ILeaveRepository _leaveRepository;
        private readonly ILeaveBalanceRepository _leaveBalanceRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public StaffController(ILeaveRepository leaveRepository, ILeaveBalanceRepository leaveBalanceRepository, ILeaveTypeRepository leaveTypeRepository, IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            _leaveRepository = leaveRepository;
            _leaveBalanceRepository = leaveBalanceRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }
        [HttpGet("Leaves/Available/{guid}")]
        public IActionResult GetAvailableLeave(Guid guid) {
            var leaveBalances = _leaveBalanceRepository.GetAll();
            var leaveType = _leaveTypeRepository.GetAll();
            if (!leaveBalances.Any() && !leaveType.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            leaveBalances = leaveBalances.Where(lb => lb.EmployeeGuid == guid && lb.IsAvailable == true);
            var availableLeave = from lb in leaveBalances
                                 join lt in leaveType on lb.LeaveTypeGuid equals lt.Guid
                                 select AvailableLeaveDto.ConvertToAvailableLeaveDto(lt, lb);

            return Ok(new ResponseOkHandler<IEnumerable<AvailableLeaveDto>>(availableLeave));
        }

        [HttpGet("Leaves/Histories/{guid}")]
        public IActionResult GetHistoryLeaves(Guid guid)
        {
            var leaves = _leaveRepository.GetAll();
            var leaveTypes = _leaveTypeRepository.GetAll();
            var employee = _employeeRepository.GetByGuid(guid);
            if (!leaves.Any() && !leaveTypes.Any() || employee is null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leavesDto = from l in leaves
                            where l.EmployeeGuid == guid
                            join lt in leaveTypes on l.LeaveTypeGuid equals lt.Guid
                            select LeaveDto.ConvertToLeaveDto(l, lt, employee);
            if (!leavesDto.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }

            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(leavesDto));
        }
     
        [HttpGet("Leaves/Pending/{guid}")]
        public IActionResult GetPendingLeaves(Guid guid)
        {
            var leaves = _leaveRepository.GetAll();
            var leaveTypes = _leaveTypeRepository.GetAll();
            var employee = _employeeRepository.GetByGuid(guid);
            if (!leaves.Any() && !leaveTypes.Any() || employee is null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leavesDto = from l in leaves
                            where l.EmployeeGuid == guid && l.Status.ToString() == "Pending"
                            join lt in leaveTypes on l.LeaveTypeGuid equals lt.Guid
                            select LeaveDto.ConvertToLeaveDto(l, lt, employee);
            if (!leavesDto.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }

            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(leavesDto));

        }
        [HttpGet("Leaves/Rejected/{guid}")]
        public IActionResult GetRejectedLeaves(Guid guid)
        {
            var leaves = _leaveRepository.GetAll();
            var leaveTypes = _leaveTypeRepository.GetAll();
            var employee = _employeeRepository.GetByGuid(guid);
            if (!leaves.Any() && !leaveTypes.Any() || employee is null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leavesDto = from l in leaves
                            where l.EmployeeGuid == guid && l.Status.ToString() == "Rejected" || l.Status.ToString() == "RejectedHR"
                            join lt in leaveTypes on l.LeaveTypeGuid equals lt.Guid
                            select LeaveDto.ConvertToLeaveDto(l, lt, employee);
            if (!leavesDto.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }

            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(leavesDto));
        }
        [HttpGet("Leaves/Approved/{guid}")]
        public IActionResult GetApprovedLeaves(Guid guid)
        {
            var leaves = _leaveRepository.GetAll();
            var leaveTypes = _leaveTypeRepository.GetAll();
            var employee = _employeeRepository.GetByGuid(guid);
            if (!leaves.Any() && !leaveTypes.Any() || employee is null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leavesDto = from l in leaves
                            where l.EmployeeGuid == guid && l.Status.ToString() == "Approved"
                            join lt in leaveTypes on l.LeaveTypeGuid equals lt.Guid
                            select LeaveDto.ConvertToLeaveDto(l, lt, employee);
            if (!leavesDto.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(leavesDto));
        }

        [HttpPost("Leaves/request")]
        public IActionResult RequestLeave(CreateLeaveDto createLeaveDto)
        {
            try
            {
                Leave toCreate = createLeaveDto;
                var leaves = _leaveRepository.GetAll().Where(l => l.EmployeeGuid == toCreate.EmployeeGuid && l.LeaveTypeGuid == toCreate.LeaveTypeGuid && l.Status.ToString() == "Pending");
                if (leaves.Any())
                {
                    return BadRequest(new ResponseBadRequestHandler("Your leave request is not approved/rejected yet"));
                }
                var employee = _employeeRepository.GetByGuid(toCreate.EmployeeGuid);
                var leaveType = _leaveTypeRepository.GetByGuid(toCreate.LeaveTypeGuid);
                var leaveBalances = _leaveBalanceRepository.GetAll();
                if (employee == null || leaveType == null || !leaveBalances.Any()) {
                    return NotFound(new ResponseNotFoundHandler("Employee or leaveType Not Found"));
                }
                var leaveBalance = leaveBalances.FirstOrDefault(lb => lb.EmployeeGuid == toCreate.EmployeeGuid && lb.LeaveTypeGuid == toCreate.LeaveTypeGuid);
                if (leaveBalance == null)
                {
                    return NotFound(new ResponseNotFoundHandler("Employee or leaveType Not Found"));
                }
                TimeSpan leaveDuration = toCreate.StartDate - toCreate.EndDate;
                int leaveLength = leaveDuration.Days;
                if (leaveType.Balance - leaveBalance.UsedBalance <= 0 && leaveLength + leaveBalance.UsedBalance >= leaveType.Balance)
                {
                    return BadRequest(new ResponseBadRequestHandler("Your leave balance is not enough"));
                }
                var result = _leaveRepository.Create(toCreate);
                return Ok(new ResponseOkHandler<string>("Leave Requested Successfully"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
            }
        }
        [HttpDelete("Leaves/{guid}")]
        public IActionResult DeleteRequest(Guid guid)
        {
            try
            {
                var leave = _leaveRepository.GetByGuid(guid);
                if (leave is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                }
                var result = _leaveRepository.Delete(leave);
                return Ok(new ResponseOkHandler<String>("Data Deleted"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
            }
        }
        [HttpGet("Profile/{guid}")]
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
    }
}
