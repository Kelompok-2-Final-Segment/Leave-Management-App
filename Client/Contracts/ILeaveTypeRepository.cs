using API.DTOs.LeaveTypes;
using API.Utilities.Handlers;

namespace Client.Contracts;

public interface ILeaveTypeRepository
{
    Task<ResponseOkHandler<IEnumerable<LeaveTypeDto>>> GetAllLeaveType();
}
