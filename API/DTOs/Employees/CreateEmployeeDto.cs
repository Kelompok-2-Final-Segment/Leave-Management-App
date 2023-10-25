
using API.Models;
using API.Utilities.Enums;

namespace API.DTOs.Employees
{
    public class CreateEmployeeDto
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid DepartmentGuid { get; set; }


        //membuat implicit operator untuk create
        public static implicit operator Employee(CreateEmployeeDto employeeDto)
        {
            return new Employee
            {
                Guid = new Guid(),
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                BirthDate = employeeDto.BirthDate,
                Gender = employeeDto.Gender,
                HiringDate = employeeDto.HiringDate,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                DepartmentGuid = employeeDto.DepartmentGuid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now

            };
        }
    }
}
