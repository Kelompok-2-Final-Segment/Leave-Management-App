using API.DTOs.Leaves;
using API.Models;
using API.Utilities.Handlers.Exceptions;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using API.Contracts;
using System;

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

        public StaffController(ILeaveRepository leaveRepository, ILeaveBalanceRepository leaveBalanceRepository, ILeaveTypeRepository leaveTypeRepository, IEmployeeRepository employeeRepository)
        {
            _leaveRepository = leaveRepository;
            _leaveBalanceRepository = leaveBalanceRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _employeeRepository = employeeRepository;
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
            var leaveDetails = from lb in leaveBalances
                               join lt in leaveType on lb.LeaveTypeGuid equals lt.Guid
                               select new LeaveDetailsDto
                               {
                                   Name = lt.Name,
                                   Balance = lt.Balance,
                                   UsedBalance = lb.UsedBalance,
                                   MinDuration = lt.MinDuration,
                                   MaxDuration =lt.MaxDuration
                               };
            return Ok(new ResponseOkHandler<IEnumerable<LeaveDetailsDto>>(leaveDetails));
        }

        [HttpGet("Leaves/Histories/{guid}")]
        public IActionResult GetHistoryLeaves(Guid guid)
        {
            var leaves = _leaveRepository.GetAll().Where(l => l.EmployeeGuid == guid);
            if (!leaves.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leavesDto = leaves.Select(l => (LeaveDto) l);
            
            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(leavesDto));
        }
     
        [HttpGet("Leaves/Pending/{guid}")]
        public IActionResult GetPendingLeaves(Guid guid)
        {
            var leaves = _leaveRepository.GetAll().Where(l => l.EmployeeGuid == guid && l.Status.ToString() == "Pending");
            if (!leaves.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leavesDto = leaves.Select(l => (LeaveDto)l);

            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(leavesDto));

        }
        [HttpGet("Leaves/Rejected/{guid}")]
        public IActionResult GetRejectedLeaves(Guid guid)
        {
             var leaves = _leaveRepository.GetAll().Where(l => l.EmployeeGuid == guid && l.Status.ToString() == "Rejected");
            if (!leaves.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leavesDto = leaves.Select(l => (LeaveDto) l);
            
            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(leavesDto));
        }
        [HttpGet("Leaves/Approved/{guid}")]
        public IActionResult GetApprovedLeaves(Guid guid)
        {
             var leaves = _leaveRepository.GetAll().Where(l => l.EmployeeGuid == guid && l.Status.ToString() == "Approved");
            if (!leaves.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leavesDto = leaves.Select(l => (LeaveDto) l);
            
            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(leavesDto));
        }

        [HttpPost("Leaves/request")]
        public IActionResult RequestLeave(CreateLeaveDto createLeaveDto)
        {
            try
            {
                Leave toCreate = createLeaveDto;
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
    }
}
