using API.DTOs.Leaves;
using API.Models;
using API.Utilities.Handlers.Exceptions;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using API.Contracts;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly ILeaveRepository _leaveRepository;

        public StaffController(ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }

        [HttpPost]
        public IActionResult RequestLeave(CreateLeaveDto createLeaveDto)
        {
            try
            {
                Leave toCreate = createLeaveDto;

                var result = _leaveRepository.Create(toCreate);
                return Ok(new ResponseOkHandler<string>("Data Created Successfully"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
            }
        }
        [HttpDelete]
        public IActionResult DeleteRequest()
        {
            return Ok();
        }
    }
}
