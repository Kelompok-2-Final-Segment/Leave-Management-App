using API.Contracts;
using API.DTOs.Accounts;
using API.Models;
using API.Utilities.Handlers.Exceptions;
using API.Utilities.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IAccountRoleRepository _accountRoleRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IEmailHandler _emailHandler;
        private readonly IJWTokenHandler _tokenHandler;
        //dependency injection dilakukan
        public AccountsController(IAccountRepository accountRepository, IEmployeeRepository employeeRepository, IEmailHandler emailHandler, IJWTokenHandler tokenHandler, IAccountRoleRepository accountRoleRepository, IRoleRepository roleRepository, IDepartmentRepository departmentRepository)
        {
            _accountRepository = accountRepository;
            _employeeRepository = employeeRepository;
            _emailHandler = emailHandler;
            _tokenHandler = tokenHandler;
            _accountRoleRepository = accountRoleRepository;
            _roleRepository = roleRepository;
            _departmentRepository = departmentRepository;
        }
        [HttpGet("ExtractToken/{Token}")]
        public IActionResult GetExtractJwt(string Token)
        {
            var claimDto = _tokenHandler.ExtractClaimsFromJwt(Token);
            if (claimDto == null)
            {
                return NotFound(new ResponseNotFoundHandler("Wrong Token"));
            }
            return Ok(new ResponseOkHandler<ClaimsDto>(claimDto));
        }

        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            try
            {
                var employee = _employeeRepository.GetByEmail(forgotPasswordDto.Email);
                if (employee is null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));
                }
                var account = _accountRepository.GetByGuid(employee.Guid);
                if (account == null)
                {
                    return NotFound(new ResponseNotFoundHandler("Account Not Found"));
                }
                //generate otp
                account.OTP = new Random().Next(100000, 1000000);
                //add 5 menit untuk otp
                account.ExpiredTime = DateTime.Now.AddMinutes(5);
                account.IsUsed = false;
                _accountRepository.Update(account);
                //penggunaan email service
                var body = $@"<p>Your OTP is {account.OTP}</p>
                  <p>You can change your password in this <a href='https://localhost:7054/changepassword'>klik this link</a></p>";
                _emailHandler.Send("Forgot Password", body, forgotPasswordDto.Email);
                return Ok(new ResponseOkHandler<string>("the OTP has been sent to your email"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Login Failed", ex.Message));
            }

        }

        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordDto changePasswordDto)
        {
            try
            {
                var employee = _employeeRepository.GetByEmail(changePasswordDto.Email);
                if (employee == null)
                {
                    return NotFound(new ResponseNotFoundHandler("Data Not Found"));
                }
                //mengambil objek axxount by id employee
                var account = _accountRepository.GetByGuid(employee.Guid);
                if (account == null)
                {
                    return NotFound(new ResponseNotFoundHandler("Account Not Found"));
                }
                if (account.OTP != changePasswordDto.Otp)
                {
                    return BadRequest(new ResponseBadRequestHandler("OTP dont Match"));
                }
                if (DateTime.Now > account.ExpiredTime)
                {
                    return BadRequest(new ResponseBadRequestHandler("OTP is expired"));
                }
                if (account.IsUsed == true)
                {
                    return BadRequest(new ResponseBadRequestHandler("OTP is already Used"));
                }
                if (changePasswordDto.NewPassword != changePasswordDto.ConfirmPassword)
                {
                    return BadRequest(new ResponseBadRequestHandler("Password dont Match"));
                }
                //hash password baru
                account.Password = HashHandler.HashPassword(changePasswordDto.NewPassword);
                account.IsUsed = true;
                _accountRepository.Update(account);
                return Ok(new ResponseOkHandler<string>("Your Password Has been changed successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to change password", ex.Message));
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto loginDto)
        {
            //mengambil objek employe by email
            var employee = _employeeRepository.GetByEmail(loginDto.Email);
            if (employee is null)
            {
                return BadRequest(new ResponseBadRequestHandler("Email or Password is invalid"));
            }
            var account = _accountRepository.GetByGuid(employee.Guid);
            if (account is null)
            {
                return NotFound(new ResponseNotFoundHandler("Account Not Found"));
            }
            var isValidPassword = HashHandler.verifvyPassword(loginDto.Password, account.Password);
            if (!isValidPassword)
            {
                return BadRequest(new ResponseBadRequestHandler("Email or Password is invalid"));
            }
            //pembuatan payload untuk jwt tokens
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, employee.Guid.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, employee.Email));
            claims.Add(new Claim(ClaimTypes.Name, string.Concat(employee.FirstName + " " + employee.LastName)));

            var getRoleName = from ar in _accountRoleRepository.GetAll()
                              join r in _roleRepository.GetAll() on ar.RoleGuid equals r.Guid
                              where ar.AccountGuid == account.Guid
                              select r.Name;

            foreach (var roleName in getRoleName)
            {
                claims.Add(new Claim(ClaimTypes.Role, roleName));

            }
            var token = _tokenHandler.Generate(claims);
            return Ok(new ResponseOkHandler<Object>("Login Success", new { Token = token }));
        }

        //[HttpPost("Register")]
        //[AllowAnonymous]
        //public IActionResult Register(RegisterDto registerDto)
        //{
        //    //mengambil objek employee
        //    using var context = _accountRepository.GetContext();
        //    using var transaction = context.Database.BeginTransaction();

        //    try
        //    {

        //        var employee = _employeeRepository.GetByEmail(registerDto.Email);
        //        if (employee != null)
        //        {
        //            return BadRequest(new ResponseBadRequestHandler("Email is Used"));

        //        }

        //        Employee employeeCreate = registerDto;
        //        employeeCreate.DepartmentGuid = _departmentRepository.GetDepartmentGuid(registerDto.DepartmentName) ?? throw new Exception("department name tidak ditemukan");

        //        _employeeRepository.Create(employeeCreate);


        //        Account account = registerDto;
        //        account.Guid = employeeCreate.Guid;

        //        account.Password = HashHandler.HashPassword(registerDto.Password);

        //        _accountRepository.Create(account);

        //        _accountRoleRepository.Create(new AccountRole
        //        {
        //            Guid = new Guid(),
        //            AccountGuid = account.Guid,
        //            RoleGuid = _roleRepository.GetRoleGuid(registerDto.RoleName) ?? throw new Exception("role name tidak ditemukan")
        //        });

        //        transaction.Commit();
        //        return Ok(new ResponseOkHandler<string>("Account Created"));
        //    }
        //    catch (Exception ex)
        //    {
        //        transaction.Rollback();
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to create account", ex.Message));
        //    }
        //}

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _accountRepository.GetAll();
            if (!result.Any())
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));
            }
            var data = result.Select(i => (AccountDto)i);
            return Ok(new ResponseOkHandler<IEnumerable<AccountDto>>(data));
        }
        //method get dari http untuk getByGuid account
        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _accountRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound(new ResponseNotFoundHandler("Data Not Found"));

            }
            return Ok(new ResponseOkHandler<AccountDto>((AccountDto)result));
        }
        ////method post dari http untuk create account
        //[HttpPost]
        //public IActionResult Create(CreateAccountDto createAccountDto)
        //{
        //    try
        //    {
        //        Account toCreate = createAccountDto;
        //        toCreate.Password = HashHandler.HashPassword(createAccountDto.Password);

        //        var result = _accountRepository.Create(toCreate);
        //        return Ok(new ResponseOkHandler<string>("Data Created Successfully"));

        //    }

        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
        //    }
        //}

        ////method put dari http untuk Update account
        //[HttpPut]
        //public IActionResult Update(AccountDto accountDto)
        //{
        //    try
        //    {
        //        var entity = _accountRepository.GetByGuid(accountDto.Guid);
        //        if (entity is null)
        //        {
        //            return NotFound(new ResponseNotFoundHandler("Data Not Found"));

        //        }
        //        entity = AccountDto.ConvertToAccount(accountDto, entity);

        //        var result = _accountRepository.Update(entity);
        //        return Ok(new ResponseOkHandler<String>("Data Updated"));

        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
        //    }

        //}
        ////method delete dari http untuk delete account
        //[HttpDelete("{guid}")]
        //public IActionResult Delete(Guid guid)
        //{
        //    try
        //    {
        //        var account = _accountRepository.GetByGuid(guid);
        //        if (account is null)
        //        {
        //            return NotFound(new ResponseNotFoundHandler("Data Not Found"));

        //        }
        //        var result = _accountRepository.Delete(account);

        //        return Ok(new ResponseOkHandler<String>("Data Deleted"));
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, new ResponseInternalServerErrorHandler("Failed to Create Data", e.Message));
        //    }
        //}
    }
}
