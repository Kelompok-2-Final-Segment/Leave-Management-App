using API.Contracts;
using API.DTOs.LeaveTypes;
using API.Models;
using API.Utilities.Handlers.Exceptions;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using API.DTOs.LeaveTypes;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveTypesController : ControllerBase
    {
        private readonly ILeaveTypeRepository _leavetyperepository;
        private readonly IEmployeeRepository _employeerepository;
        private readonly ILeaveBalanceRepository _leavebalancerepository;

        public LeaveTypesController(ILeaveTypeRepository leavetyperepository, ILeaveBalanceRepository leavebalancerepository, IEmployeeRepository employeerepository)
        {
            _leavetyperepository = leavetyperepository;
            _leavebalancerepository = leavebalancerepository;
            _employeerepository = employeerepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _leavetyperepository.GetAll();
            if (!result.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var data = result.Select(i => (LeaveTypeDto)i);
            return Ok(new ResponseOkHandler<IEnumerable<LeaveTypeDto>>(data));
        }

        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _leavetyperepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));

            }
            return Ok(new ResponseOkHandler<LeaveTypeDto>((LeaveTypeDto)result));
        }

        [HttpPost]
        public IActionResult Create(CreateLeaveTypeDto createLeaveTypeDto)
        {
            try
            {
                LeaveType toCreate = createLeaveTypeDto;
                var result = _leavetyperepository.Create(toCreate);
                var employee = _employeerepository.GetAll();
                foreach (var item in employee)
                {
                    var available = true;
                    if (toCreate.FemaleOnly == true && item.Gender.ToString() == "Male")
                    {
                        available = false;
                    }
                    var leaveBalance = new LeaveBalance
                    {
                        Guid = Guid.NewGuid(),
                        UsedBalance = 0,
                        IsAvailable = available,
                        LeaveTypeGuid = toCreate.Guid,
                        EmployeeGuid = item.Guid,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    };
                    _leavebalancerepository.Create(leaveBalance);
                }
                return Ok(new ResponseOkHandler<string>("Data Created Successfully"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
            }
        }


        [HttpPut]
        public IActionResult Update(LeaveTypeDto leaveTypeDto)
        {
            try
            {
                var entity = _leavetyperepository.GetByGuid(leaveTypeDto.Guid);
                if (entity is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                }
                entity = LeaveTypeDto.ConvertToLeaveType(leaveTypeDto, entity);

                var result = _leavetyperepository.Update(entity);
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
                var leaveType = _leavetyperepository.GetByGuid(guid);
                if (leaveType is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                }
                var result = _leavetyperepository.Delete(leaveType);
                return Ok(new ResponseOkHandler<String>("Data Deleted"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
            }

        }
    }
}
