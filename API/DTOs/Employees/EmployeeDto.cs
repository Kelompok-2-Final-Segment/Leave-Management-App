

using API.DTOs.Accounts;
using API.Models;
using API.Utilities.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Employees
{
    public class EmployeeDto
    {
        public Guid Guid { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public Guid DepartmentGuid { get; set; }


        //membuat implicit operator untuk update
        public static Employee ConvertToEMployee(EmployeeDto employeeDto, Employee employee)
        {

            employee.FirstName = employeeDto.FirstName;
            employee.LastName = employeeDto.LastName;
            employee.BirthDate = employeeDto.BirthDate;
            employee.Gender = employeeDto.Gender;
            employee.HiringDate = employeeDto.HiringDate;
            employee.Email = employeeDto.Email;
            employee.PhoneNumber = employeeDto.PhoneNumber;
            employee.DepartmentGuid = employeeDto.DepartmentGuid;
            employee.ModifiedDate = DateTime.Now;
            return employee;

        }      
        public static Employee ConvertToEMployee(RegisterDto employeeDto, Employee employee)
        {

            employee.FirstName = employeeDto.FirstName;
            employee.LastName = employeeDto.LastName;
            employee.BirthDate = employeeDto.BirthDate;
            employee.Gender = employeeDto.Gender;
            employee.HiringDate = employeeDto.HiringDate;
            employee.Email = employeeDto.Email;
            employee.PhoneNumber = employeeDto.PhoneNumber;
            employee.DepartmentGuid = employee.DepartmentGuid;
            employee.ModifiedDate = DateTime.Now;
            return employee;

        }
        //membuat explicit operator untuk response get, create , getbyid
        public static explicit operator EmployeeDto(Employee employee)
        {
            return new EmployeeDto
            {
                Guid = employee.Guid,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                Gender = employee.Gender,
                HiringDate = employee.HiringDate,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                DepartmentGuid = employee.DepartmentGuid,

            };
        }

    }
}
