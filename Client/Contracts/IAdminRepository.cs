using API.DTOs.Accounts;
using API.DTOs.Employees;
using API.Utilities.Handlers;

namespace Client.Contracts;
 
public interface IAdminRepository
{
    Task<ResponseOkHandler<IEnumerable<EmployeeDetailsDto>>> GetAllEmployee();
    Task<ResponseOkHandler<EmployeeDetailsDto>> GetEmployeeByGuid(Guid guid);
    Task<ResponseOkHandler<string>> RegisterEmployee(RegisterDto entity);
    Task<ResponseOkHandler<string>> DeleteEmployee(Guid guid);
}
