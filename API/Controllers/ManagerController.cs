using API.Contracts;
using API.DTOs.Accounts;
using API.Models;
using API.Repositories;
using API.Utilities.Handlers.Exceptions;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using API.DTOs.Employees;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public ManagerController(IAccountRepository accountRepository, IDepartmentRepository departmentRepository, IRoleRepository roleRepository, IEmployeeRepository employeeRepository)
        {
            _accountRepository = accountRepository;
            _departmentRepository = departmentRepository;
            _roleRepository = roleRepository;
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public IActionResult GetStaff(EmployeeDto employeeDto)
        {
            var result = _employeeRepository.GetAll();
            if (!result.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var data =  result.Where(i =>  i.DepartmentGuid == employeeDto.DepartmentGuid).Select(i => (EmployeeDto) i);
            return Ok(new ResponseOkHandler<IEnumerable<EmployeeDto>>(data));
        }
        [HttpDelete]
        public IActionResult DeleteStaff()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult EditStaff()
        {
            return BadRequest();
        }
        [HttpPut("Leave")]
        public IActionResult EditLeave()
        {
            return Ok();
        }
    }
}
