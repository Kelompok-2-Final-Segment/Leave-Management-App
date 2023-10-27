﻿using API.DTOs.Accounts;
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
        private readonly ILeaveBalanceRepository _leaveBalanceRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public AdminController(IAccountRepository accountRepository, IDepartmentRepository departmentRepository, IRoleRepository roleRepository, IEmployeeRepository employeeRepository, IAccountRoleRepository accountRoleRepository, ILeaveBalanceRepository leaveBalanceRepository, ILeaveTypeRepository leaveTypeRepository)
        {
            _accountRepository = accountRepository;
            _departmentRepository = departmentRepository;
            _roleRepository = roleRepository;
            _employeeRepository = employeeRepository;
            _accountRoleRepository = accountRoleRepository;
            _leaveBalanceRepository = leaveBalanceRepository;
            _leaveTypeRepository = leaveTypeRepository;
        }
        [HttpGet("Employees")]
        public IActionResult GetEmployees()
        {
            var employees = _employeeRepository.GetAll();
            var accountRoles = _accountRoleRepository.GetAll();
            var departments = _departmentRepository.GetAll();

            if (!employees.Any() && !accountRoles.Any() && !departments.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var employeeDetails = from emp in employees
                                  join ar in accountRoles on emp.Guid equals ar.AccountGuid
                                  join d in departments on emp.DepartmentGuid equals d.Guid
                                  select new EmployeeDetailsDto
                                  {
                                      Guid = emp.Guid,
                                      FullName = string.Concat(emp.FirstName, " ", emp.LastName),
                                      BirthDate = emp.BirthDate,
                                      HiringDate = emp.HiringDate,
                                      Gender = emp.Gender.ToString(),
                                      Email = emp.Email,
                                      PhoneNumber = emp.PhoneNumber,
                                      DepartmentName = d.Name,
                                      RoleName = _roleRepository.GetRoleName(ar.RoleGuid) ?? throw new Exception("no role ")
                                  };

            return Ok(new ResponseOkHandler<IEnumerable<EmployeeDetailsDto>>(employeeDetails));
        }
        [HttpGet("Employees/{guid}")]
        public IActionResult GetEmployeeByGuid(Guid guid)
        {
            var employee = _employeeRepository.GetByGuid(guid);
            if(employee == null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var accountRole = _accountRoleRepository.GetAll().FirstOrDefault(ar => ar.AccountGuid == employee.Guid);
            var department = _departmentRepository.GetByGuid(employee.DepartmentGuid);

            if (accountRole == null || department == null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var employeeDetail = new EmployeeDetailsDto
                                 {
                                      Guid = employee.Guid,
                                      FullName = string.Concat(employee.FirstName, " ", employee.LastName),
                                      BirthDate = employee.BirthDate,
                                      HiringDate = employee.HiringDate,
                                      Gender = employee.Gender.ToString(),
                                      Email = employee.Email,
                                      PhoneNumber = employee.PhoneNumber,
                                      DepartmentName = department.Name,
                                      RoleName = _roleRepository.GetRoleName(accountRole.RoleGuid) ?? throw new Exception("no role ")
                                  };

            return Ok(new ResponseOkHandler<EmployeeDetailsDto>(employeeDetail));
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
                var leavetypes = _leaveTypeRepository.GetAll();
                if (!leavetypes.Any())
                {
                    return NotFound(new ResponseNotFoundHandler("isi leaveType minimal satu"));
                }
                foreach (var item in leavetypes)
                {
                    LeaveBalance leaveBalance = new LeaveBalance
                    {
                        Guid = Guid.NewGuid(),
                        LeaveTypeGuid = item.Guid,
                        EmployeeGuid = account.Guid,
                        UsedBalance = 0,
                        IsAvailable = true,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now
                    };
                    _leaveBalanceRepository.Create(leaveBalance);
                };

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
            try
            {
                var employee = _employeeRepository.GetByGuid(guid);
                if (employee is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                }
                var result = _employeeRepository.Delete(employee);
                return Ok(new ResponseOkHandler<String>("Data Deleted"));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
            }

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
