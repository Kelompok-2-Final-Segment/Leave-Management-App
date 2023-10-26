using API.DTOs.Accounts;
using API.Models;

namespace API.DTOs.Employees
{

    public class EmployeeDetailsDto
    {
        public Guid Guid { get; set; }
        public string NIK { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Role> Roles { get; set; }


        //membuat explicit operator untuk response get, create , getbyid
        public static EmployeeDetailsDto ConvertToEmployeeDetails(Employee employee, IEnumerable< Role> roles, IEnumerable<Department> departments)
        {
            return new EmployeeDetailsDto
            {
                Guid = employee.Guid,
                NIK = employee.NIK,
                FullName = employee.FirstName + " " + employee.LastName,
                BirthDate = employee.BirthDate,
                Gender = employee.Gender.ToString(),
                HiringDate = employee.HiringDate,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Departments = departments,
                Roles = roles
            };
        }
    }
}

