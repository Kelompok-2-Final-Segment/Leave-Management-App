using API.DTOs.Leaves;
using API.Models;
using API.Utilities.Handlers.Exceptions;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using API.Contracts;
using System;
using API.DTOs.Employees;
using API.Repositories;
using API.Utilities.Enums;
using Microsoft.AspNetCore.Authorization;

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
        [HttpGet("Leaves/Statistics/{guid}")]
        public IActionResult GetLeaveBreakdown(Guid guid) {
            var leaves = _leaveRepository.GetAll().Where(l =>l.EmployeeGuid == guid);
            if (!leaves.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            int requestCount = leaves.Count();
            int approvedCount = leaves.Count(l => l.Status.ToString() == "Approved");
            int rejectedCount = leaves.Count(l => l.Status.ToString() == "Rejected" || l.Status.ToString() == "RejectedHR");
            int pendingCount = leaves.Count(l => l.Status.ToString() == "Pending" || l.Status.ToString() == "Accepted");
            int cancelledCount = leaves.Count(l => l.Status.ToString() == "Cancelled");
            var leavestatisticDto = new LeaveStatisticStaffDto { 
                TotalRequest = requestCount,
                Approved = approvedCount,
                Rejected = rejectedCount,
                Pending = pendingCount,
                Cancelled = cancelledCount
            };
            return Ok(new ResponseOkHandler<LeaveStatisticStaffDto>(leavestatisticDto));
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
            var leaveDetailManagerDto = LeaveDetailAdminDto.ConvertToLeaveDetailAdminDto(leave, leaveType, department, employee);


            return Ok(new ResponseOkHandler<LeaveDetailAdminDto>(leaveDetailManagerDto));

        }

        [HttpGet("Leaves/Available/{guid}")]
        [AllowAnonymous]
        public IActionResult GetAvailableLeave(Guid guid) {
            var leaveBalances = _leaveBalanceRepository.GetAll().Where(lb => lb.EmployeeGuid == guid && lb.IsAvailable == true); ;
            var leaveType = _leaveTypeRepository.GetAll();
            if (!leaveBalances.Any() && !leaveType.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
    
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
                TimeSpan leaveDuration = toCreate.EndDate - toCreate.StartDate;
                int leaveLength = leaveDuration.Days;
                if (leaveLength <= 0) {
                    return BadRequest(new ResponseBadRequestHandler("Your leave date plan is wrong"));
                }
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
        [HttpPut("Leaves/{guid}")]
        public IActionResult CancelRequest(Guid guid)
        {
            try
            {
                var leave = _leaveRepository.GetByGuid(guid);
                if (leave is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                }
                leave.Status = StatusLevel.Cancelled;
                var result = _leaveRepository.Update(leave);
                return Ok(new ResponseOkHandler<String>("Data Updated"));

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

        [HttpPut("Profile/Edit/{guid}")]
        public IActionResult EditStaff(EmployeeDto employeeDto)
        {
            try
            {
                var entity = _employeeRepository.GetByEmail(employeeDto.Email);
                if (entity is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));
                }

                entity = EmployeeDto.ConvertToEMployee(employeeDto, entity);

                var result = _employeeRepository.Update(entity);

                return Ok(new ResponseOkHandler<String>("Data Updated"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Update Data", e.Message));
            }
        }
    }
}
