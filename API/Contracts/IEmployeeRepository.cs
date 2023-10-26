using API.DTOs.Employees;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Contracts
{
    public interface IEmployeeRepository : IGeneralRepository<Employee>
    {
        public string? GetLastNik();
        public Employee? GetByEmail(string email);
   
    }
}
