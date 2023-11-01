using API.DTOs.Accounts;
using API.Models;
using API.Utilities.Handlers.Exceptions;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using API.Contracts;
using API.DTOs.Employees;
using API.Utilities.Enums;
using API.DTOs.Leaves;
using API.Repositories;

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
        private readonly ILeaveRepository _leaveRepository;

        public AdminController(IAccountRepository accountRepository, IDepartmentRepository departmentRepository, IRoleRepository roleRepository, IEmployeeRepository employeeRepository, IAccountRoleRepository accountRoleRepository, ILeaveBalanceRepository leaveBalanceRepository, ILeaveTypeRepository leaveTypeRepository, ILeaveRepository leaveRepository)
        {
            _accountRepository = accountRepository;
            _departmentRepository = departmentRepository;
            _roleRepository = roleRepository;
            _employeeRepository = employeeRepository;
            _accountRoleRepository = accountRoleRepository;
            _leaveBalanceRepository = leaveBalanceRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _leaveRepository = leaveRepository;
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
                                      NIK = emp.NIK,
                                      FirstName = emp.FirstName,
                                      LastName = emp.LastName,
                                      BirthDate = emp.BirthDate,
                                      HiringDate = emp.HiringDate,
                                      Gender = emp.Gender.ToString(),
                                      Email = emp.Email,
                                      PhoneNumber = emp.PhoneNumber,
                                      DepartmentName = d.Name,
                                      RoleName = _roleRepository.GetRoleName(ar.RoleGuid) ?? "No role"
                                  };

            return Ok(new ResponseOkHandler<IEnumerable<EmployeeDetailsDto>>(employeeDetails));
        }
        [HttpGet("Employees/{guid}")]
        public IActionResult GetEmployeeByGuid(Guid guid)
        {
            var employee = _employeeRepository.GetByGuid(guid);
            if (employee == null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var accountRole = _accountRoleRepository.GetAll().FirstOrDefault(ar => ar.AccountGuid == employee.Guid);
            var department = _departmentRepository.GetByGuid(employee.DepartmentGuid);

            if (accountRole == null || department == null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var roleName = _roleRepository.GetRoleName(accountRole.RoleGuid) ?? "no Role";
            var employeeDetail = EmployeeDetailsDto.ConvertToEmployeeDetails(employee, roleName, department);

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
                if (registerDto.RoleName == "Manager")
                {
                    var toUpdateManager = _departmentRepository.GetByGuid(employeeCreate.DepartmentGuid);
                    if (toUpdateManager != null && toUpdateManager.ManagerGuid == null)
                    {
                        toUpdateManager.ManagerGuid = employeeCreate.Guid;
                        _departmentRepository.Update(toUpdateManager);
                    }
                    else
                    {
                        return BadRequest(new ResponseBadRequestHandler("Setiap department hanya boleh memiliki satu manager"));
                    }

                }
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
                    var available = true;
                    if (item.FemaleOnly == true && employeeCreate.Gender.ToString() == "Male")
                    {
                        available = false;
                    }
                    if (item.Name == "Annual Leave" && employeeCreate.HiringDate <= DateTime.Today.AddYears(-1))
                    {
                        available = false;
                    }
                    LeaveBalance leaveBalance = new LeaveBalance
                    {
                        Guid = Guid.NewGuid(),
                        LeaveTypeGuid = item.Guid,
                        EmployeeGuid = account.Guid,
                        UsedBalance = 0,
                        IsAvailable = available,
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
                var departmentGuid = _departmentRepository.GetDepartmentGuid(registerDto.DepartmentName);
                if (departmentGuid is null)
                {
                    
                    return NotFound(new ResponseNotFoundHandler("Department Not Found"));
                }
                
                entity = EmployeeDto.ConvertToEMployee(registerDto, entity);
                entity.DepartmentGuid = (Guid)departmentGuid;
                var result = _employeeRepository.Update(entity);
                var accountRoleToUpdate = _accountRoleRepository.GetAll().FirstOrDefault(ar => ar.AccountGuid == entity.Guid);
                var roleGuid = _roleRepository.GetRoleGuid(registerDto.RoleName);
                if (roleGuid is null || accountRoleToUpdate is null)
                { 
                    return NotFound(new ResponseNotFoundHandler("Role Not Found"));
                }
                accountRoleToUpdate.RoleGuid = (Guid) roleGuid;
                _accountRoleRepository.Update(accountRoleToUpdate);
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

        [HttpGet("Leaves/Statistics")]
        public IActionResult GetStatisticLeaves()
        {
            var employees = _employeeRepository.GetAll();
            var departments = _departmentRepository.GetAll();
            var leaves = _leaveRepository.GetAll();

            if (!leaves.Any() && !employees.Any() && !departments.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }

            var leaveStatistic = LeaveStatisticDto.ConvertToStatisticLeave(employees,departments, leaves);

            return Ok(new ResponseOkHandler<LeaveStatisticDto>(leaveStatistic));
        }

        [HttpGet("Leaves/Histories")]
        public IActionResult GetAllLeaves()
        {

            var leaves = _leaveRepository.GetAll();
            var leaveTypes = _leaveTypeRepository.GetAll();
            var employees = _employeeRepository.GetAll();
            if (!leaves.Any() &&!leaveTypes.Any() &&!employees.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leavesDto = from l in leaves
                            join lt in leaveTypes on l.LeaveTypeGuid equals lt.Guid
                            join emp in employees on l.EmployeeGuid equals emp.Guid
                            select LeaveDto.ConvertToLeaveDto(l, lt, emp);
                           
            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(leavesDto));

        }

        [HttpGet("Leaves/Details/{guid}")]
        public IActionResult GetLeaveDetails(Guid guid)
        {
            var leave = _leaveRepository.GetByGuid(guid);
            if (leave == null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leaveType = _leaveTypeRepository.GetByGuid(leave.LeaveTypeGuid);
            var employee = _employeeRepository.GetByGuid(leave.EmployeeGuid);
            if (employee == null || leaveType == null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var department = _departmentRepository.GetByGuid(employee.DepartmentGuid);
            if (department == null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leaveDetailAdminDto = LeaveDetailAdminDto.ConvertToLeaveDetailAdminDto(leave,leaveType,department,employee);


            return Ok(new ResponseOkHandler<LeaveDetailAdminDto>(leaveDetailAdminDto));

        }

        [HttpGet("Leaves/Pending")]
        public IActionResult GetPendingLeaves()
        {
            var leaves = _leaveRepository.GetAll();
            var leaveTypes = _leaveTypeRepository.GetAll();
            var employees = _employeeRepository.GetAll();
            if (!leaves.Any() && !leaveTypes.Any() && !employees.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leavesDto = from l in leaves
                            where l.Status.ToString() == "Accepted"
                            join lt in leaveTypes on l.LeaveTypeGuid equals lt.Guid
                            join emp in employees on l.EmployeeGuid equals emp.Guid
                            select LeaveDto.ConvertToLeaveDto(l, lt, emp);

            if (!leavesDto.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(leavesDto));

        }

        [HttpGet("Leaves/Rejected")]
        public IActionResult GetRejectedLeaves()
        {
            var leaves = _leaveRepository.GetAll();
            var leaveTypes = _leaveTypeRepository.GetAll();
            var employees = _employeeRepository.GetAll();
            if (!leaves.Any() && !leaveTypes.Any() && !employees.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leavesDto = from l in leaves
                            where l.Status.ToString() == "RejectedHR"
                            join lt in leaveTypes on l.LeaveTypeGuid equals lt.Guid
                            join emp in employees on l.EmployeeGuid equals emp.Guid
                            select LeaveDto.ConvertToLeaveDto(l, lt, emp);
        
            if (!leavesDto.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(leavesDto));
        }
        [HttpGet("Leaves/Approved")]
        public IActionResult GetApprovedLeaves(Guid guid)
        {
            var leaves = _leaveRepository.GetAll();
            var leaveTypes = _leaveTypeRepository.GetAll();
            var employees = _employeeRepository.GetAll();
            if (!leaves.Any() && !leaveTypes.Any() && !employees.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var leavesDto = from l in leaves
                            where l.Status.ToString() == "Approved"
                            join lt in leaveTypes on l.LeaveTypeGuid equals lt.Guid
                            join emp in employees on l.EmployeeGuid equals emp.Guid
                            select LeaveDto.ConvertToLeaveDto(l, lt, emp);
   
            if (!leavesDto.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            return Ok(new ResponseOkHandler<IEnumerable<LeaveDto>>(leavesDto));
        }

        [HttpPut("Leaves/Edit")]
        public IActionResult EditLeave(EditLeaveDto editLeaveDto)
        {
            try
            {
                var entity = _leaveRepository.GetByGuid(editLeaveDto.Guid);
                var leaveBalances = _leaveBalanceRepository.GetAll();
                if (entity is null || leaveBalances == null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                }
                entity = EditLeaveDto.EditLeaveByHR(editLeaveDto, entity);
                if (entity.Status.ToString() == "Approved")
                {

                    var leaveBalance = leaveBalances.FirstOrDefault(lb => lb.EmployeeGuid == entity.EmployeeGuid && lb.LeaveTypeGuid == entity.LeaveTypeGuid);
                    if (leaveBalance == null)
                    {
                        return NotFound(new ResponseNotFoundHandler("Data Not Found"));

                    }
                    TimeSpan leaveDuration = entity.StartDate - entity.EndDate;
                    int leaveLength = leaveDuration.Days;
                    leaveBalance.UsedBalance += leaveLength;
                    _leaveBalanceRepository.Update(leaveBalance);
                }
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
