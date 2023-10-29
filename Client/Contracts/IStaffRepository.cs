using API.DTOs.Employees;

namespace Client.Contracts;

public interface IStaffRepository : IRepository<EmployeeDto, Guid>
{

}
