using API.Contracts;
using API.DTOs.LeaveBalances;
using API.Models;
using API.Utilities.Handlers.Exceptions;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveBalancesController : ControllerBase
    {
        private readonly ILeaveBalanceRepository _leaveBalanceRepository;

        public LeaveBalancesController(ILeaveBalanceRepository leaveBalanceRepository)
        {
            _leaveBalanceRepository = leaveBalanceRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _leaveBalanceRepository.GetAll();
            if (!result.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var data = result.Select(i => (LeaveBalanceDto)i);
            return Ok(new ResponseOkHandler<IEnumerable<LeaveBalanceDto>>(data));
        }

        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _leaveBalanceRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));

            }
            return Ok(new ResponseOkHandler<LeaveBalanceDto>((LeaveBalanceDto)result));
        }

        [HttpPost]
        public IActionResult Create(CreateLeaveBalanceDto createLeaveBalanceDto)
        {
            try
            {
                LeaveBalance toCreate = createLeaveBalanceDto;

                var result = _leaveBalanceRepository.Create(toCreate);
                return Ok(new ResponseOkHandler<string>("Data Created Successfully"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
            }
        }


        [HttpPut]
        public IActionResult Update(LeaveBalanceDto leaveBalanceDto)
        {
            try
            {
                var entity = _leaveBalanceRepository.GetByGuid(leaveBalanceDto.Guid);
                if (entity is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                }
                entity = (LeaveBalance)leaveBalanceDto;
                entity.ModifiedDate = DateTime.Now;

                var result = _leaveBalanceRepository.Update(entity);
                return Ok(new ResponseOkHandler<String>("Data Updated"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
            }

        }

        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            try
            {
                var leaveBalance = _leaveBalanceRepository.GetByGuid(guid);
                if (leaveBalance is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                }
                var result = _leaveBalanceRepository.Delete(leaveBalance);
                return Ok(new ResponseOkHandler<String>("Data Deleted"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
            }

        }
    }
}
