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
                if (leaveType.Balance - leaveBalance.UsedBalance <= 0)
                {
                    return BadRequest(new ResponseBadRequestHandler("You Can't Request This Leave"));
                }
                var result = _leaveRepository.Create(toCreate);
                return Ok(new ResponseOkHandler<string>("Leave Requested Successfully"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
            }
        }
        [HttpDelete("{guid}")]
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
