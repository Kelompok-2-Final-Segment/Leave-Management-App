using API.DTOs.Accounts;
using API.Models;
using API.Utilities.Handlers.Exceptions;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using API.Contracts;
using API.DTOs.Employees;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAccountRoleRepository _accountRoleRepository;

        public AdminController(IAccountRepository accountRepository, IDepartmentRepository departmentRepository, IRoleRepository roleRepository, IEmployeeRepository employeeRepository, IAccountRoleRepository accountRoleRepository)
        {
            _accountRepository = accountRepository;
            _departmentRepository = departmentRepository;
            _roleRepository = roleRepository;
            _employeeRepository = employeeRepository;
            _accountRoleRepository = accountRoleRepository;
        }
        [HttpGet("Employees")]
        public IActionResult GetEmployees()
        {
            return Ok();
        }

        [HttpPost("Employees/Register")]
        public IActionResult RegisterEmployee(RegisterDto registerDto)
        {
            using var context = _accountRepository.GetContext();
            using var transaction = context.Database.BeginTransaction();

            try
            {

                var employee = _employeeRepository.GetByEmail(registerDto.Email);
                if (employee != null)
                {
                    return BadRequest(new ResponseBadRequestHandler("Email is Used"));
                }

                Employee employeeCreate = registerDto;
                employeeCreate.NIK = GenerateNIKHandler.GenerateNIK(_employeeRepository.GetLastNik());
                employeeCreate.DepartmentGuid = _departmentRepository.GetDepartmentGuid(registerDto.DepartmentName) ?? throw new Exception("department name tidak ditemukan");

                _employeeRepository.Create(employeeCreate);


                Account account = registerDto;
                account.Guid = employeeCreate.Guid;

                account.Password = HashHandler.HashPassword(registerDto.Password);

                _accountRepository.Create(account);

                _accountRoleRepository.Create(new AccountRole
                {
                    Guid = new Guid(),
                    AccountGuid = account.Guid,
                    RoleGuid = _roleRepository.GetRoleGuid(registerDto.RoleName) ?? throw new Exception("role name tidak ditemukan")
                });

                transaction.Commit();
                return Ok(new ResponseOkHandler<string>("Account Created"));
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to create account", ex.Message));
            }
        }

        [HttpPut("Employees/Edit")]
        public IActionResult EditEmployee(RegisterDto registerDto)
        {
            try
            {
                var entity = _employeeRepository.GetByEmail(registerDto.Email);
                if (entity is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));
                }

                entity = EmployeeDto.ConvertToEMployee(registerDto, entity);
                var result = _employeeRepository.Update(entity);
                return Ok(new ResponseOkHandler<String>("Data Updated"));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Update Data", e.Message));
            }
        }
        [HttpDelete("Employees/Delete/{guid}")]
        public IActionResult DeleteEmployee(Guid guid)
        {
            return Ok();
        }
        [HttpGet("Leaves")]
        public IActionResult GetAll()
        {
            return Ok();
        }
        [HttpPut("Leaves/Edit")]
        public IActionResult EditLeave()
        {
            return BadRequest();
        }
    }
}
