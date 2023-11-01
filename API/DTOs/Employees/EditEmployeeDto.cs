using API.Models;
using API.Utilities.Enums;

namespace API.DTOs.Employees
{
    public class EditEmployeeDto
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DepartmentName { get; set; }
        public string RoleName { get; set; }

        public static Employee ConvertToEmployee(EditEmployeeDto editEmployeeDto)
        {
            return new Employee
            {
                FirstName = editEmployeeDto.FirstName,
                LastName = editEmployeeDto.LastName,
                BirthDate = editEmployeeDto.BirthDate,
                HiringDate = editEmployeeDto.HiringDate,
                Gender = editEmployeeDto.Gender,
                Email = editEmployeeDto.Email,
                PhoneNumber = editEmployeeDto.PhoneNumber,
            };
        }
    }
}
