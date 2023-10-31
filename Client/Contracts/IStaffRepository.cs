using API.DTOs.Employees;
using API.DTOs.Leaves;
using API.Utilities.Handlers;

namespace Client.Contracts;

public interface IStaffRepository
{
    public Task<ResponseOkHandler< IEnumerable<AvailableLeaveDto>>> GetAvailableLeaves(Guid guid);
    public Task<ResponseOkHandler<string>> RequestALeave(CreateLeaveDto createLeaveDto);
    public Task<ResponseOkHandler<EmployeeDetailsDto>> Profile(Guid guid);
}
