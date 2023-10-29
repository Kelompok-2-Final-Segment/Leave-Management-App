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
    public class LeavesController : ControllerBase
    {

        private readonly ILeaveRepository _leaveRepository;

        public LeavesController(ILeaveRepository leaveRepository)
        {
            _leaveRepository = leaveRepository;
        }
        

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _leaveRepository.GetAll();
            if (!result.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var data = result.Select(i => (LeaveDetailStaffDto) i);
            return Ok(new ResponseOkHandler<IEnumerable<LeaveDetailStaffDto>>(data));
        }

        //[HttpGet("{guid}")]
        //public IActionResult GetByGuid(Guid guid)
        //{
        //    var result = _leaveRepository.GetByGuid(guid);
        //    if (result is null)
        //    {
        //        return NotFound(new ResponseNotFoundHandler("Data Not Found"));

        //    }
        //    return Ok(new ResponseOkHandler<LeaveDto>((LeaveDto)result));
        //}



        //[HttpPut]
        //public IActionResult Update(LeaveDto leaveDto)
        //{
        //    try
        //    {
        //        var entity = _leaveRepository.GetByGuid(leaveDto.Guid);
        //        if (entity is null)
        //        {
        //            return NotFound(new ResponseNotFoundHandler("Data Not Found"));

        //        }
        //        entity = LeaveDto.ConvertToLeave(leaveDto, entity);

        //        var result = _leaveRepository.Update(entity);
        //        return Ok(new ResponseOkHandler<String>("Data Updated"));

        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
        //    }

        //}

        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
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
