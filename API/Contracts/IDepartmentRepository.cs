using API.DTOs.Departments;
using API.Models;

namespace API.Contracts
{
    public interface IDepartmentRepository : IGeneralRepository<Department>
    {
        Guid? GetDepartmentGuid(string departName);
        Department? GetDepartmentByManagerGuid(Guid guid);
    }
}
