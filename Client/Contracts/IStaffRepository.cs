using API.DTOs.Employees;
using API.DTOs.Leaves;
using API.Utilities.Handlers;

namespace Client.Contracts;

public interface IStaffRepository
{
    public Task<ResponseOkHandler< IEnumerable<AvailableLeaveDto>>> GetAvailableLeaves(Guid guid);
    public Task<ResponseOkHandler<string>> RequestALeave(CreateLeaveDto createLeaveDto);
    public Task<ResponseOkHandler<EmployeeDetailsDto>> Profile(Guid guid);
    public Task<ResponseOkHandler<IEnumerable<LeaveDto>>> GetHistoryLeaves(Guid guid);
    public Task<ResponseOkHandler<IEnumerable<LeaveDto>>> GetPendingLeaves(Guid guid);
    public Task<ResponseOkHandler<LeaveDetailAdminDto>> GetLeaveDetail(Guid guid);
    public Task<ResponseOkHandler<LeaveStatisticStaffDto>> GetStatisticLeaves(Guid guid);
}
