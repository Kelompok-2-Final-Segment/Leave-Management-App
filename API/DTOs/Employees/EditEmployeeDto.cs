using API.Models;
using API.Utilities.Enums;

namespace API.DTOs.Employees
{
    public class EditEmployeeDto
    {
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DepartmentName { get; set; }
        public string RoleName { get; set; }

        public static Employee ConvertToEmployee(EditEmployeeDto editEmployeeDto, Employee employee)
        {

            employee.FirstName = editEmployeeDto.FirstName;
            employee.LastName = editEmployeeDto.LastName;
            employee.BirthDate = editEmployeeDto.BirthDate;
            employee.HiringDate = editEmployeeDto.HiringDate;
            employee.Gender = editEmployeeDto.Gender;
            employee.Email = editEmployeeDto.Email;
            employee.PhoneNumber = editEmployeeDto.PhoneNumber;
            return employee;

        }
    }
}
