using API.DTOs.Accounts;
using API.DTOs.Employees;
using API.Utilities.Handlers;

namespace Client.Contracts;
 
public interface IAdminRepository
{
    Task<ResponseOkHandler<IEnumerable<EmployeeDetailsDto>>> GetAllEmployee();
    Task<ResponseOkHandler<string>> RegisterEmployee(RegisterDto entity);

}
