
using API.Models;
using API.Utilities.Enums;

namespace API.DTOs.Accounts
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string RoleName { get; set; }
        public string DepartmentName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        //membuat implicit operator untuk create
        public static implicit operator Employee(RegisterDto employeeDto)
        {
            return new Employee
            {
                Guid = Guid.NewGuid(),
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                BirthDate = employeeDto.BirthDate,
                HiringDate = employeeDto.HiringDate,
                Gender = employeeDto.Gender,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now

            };
        }



        public static implicit operator Account(RegisterDto createAccountDto)
        {
            return new Account
            {
                OTP = 0,
                IsUsed = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                
            };
        }
    }
}
