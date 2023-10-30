using API.DTOs.LeaveTypes;
using API.Utilities.Handlers;

namespace Client.Contracts;

public interface ILeaveTypeRepository
{
    Task<ResponseOkHandler<IEnumerable<LeaveTypeDto>>> GetAll();
    Task<ResponseOkHandler<LeaveTypeDto>> GetByGuid(Guid guid);
    Task<ResponseOkHandler<string>> Delete(Guid guid);
    Task<ResponseOkHandler<string>> Create(CreateLeaveTypeDto entity);
    Task<ResponseOkHandler<string>> Update(LeaveTypeDto entity);

}
