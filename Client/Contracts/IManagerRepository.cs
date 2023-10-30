using API.DTOs.Employees;
using API.DTOs.Leaves;
using API.DTOs.Managers;
using API.Models;
using API.Utilities.Handlers;

namespace Client.Contracts
{
    public interface IManagerRepository
    {
        public Task<ResponseOkHandler<DashboardManagerDto>> GetDashboardDetails(Guid guid);
        public Task<ResponseOkHandler<IEnumerable<LeaveDto>>> GetPendingLeaves(Guid guid);
        public Task<ResponseOkHandler<IEnumerable<LeaveDto>>> GetHistoryLeaves(Guid guid);
        public Task<ResponseOkHandler<LeaveStatisticDto>> GetStatisticLeaves(Guid guid);
        public Task<ResponseOkHandler<IEnumerable<EmployeeDto>>> GetStaffs(Guid guid);
        public Task<ResponseOkHandler<EmployeeDetailsDto>> GetStaff(Guid guid);
        public Task<ResponseOkHandler<LeaveDetailManagerDto>> GetLeaveDetails(Guid guid);
        public Task<ResponseOkHandler<string>> EditLeave(EditLeaveDto editLeaveDto);
    }
}
