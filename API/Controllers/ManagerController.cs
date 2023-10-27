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

        public ManagerController(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository, ILeaveRepository leaveRepository)
        {

            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
            _leaveRepository = leaveRepository;
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

        [HttpPut("Staffs")]
        public IActionResult EditStaff()
        {
            return BadRequest();
        }
        [HttpPut("Leaves/{guid}")]
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
