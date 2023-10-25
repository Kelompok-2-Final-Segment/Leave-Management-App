using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class LeaveTypeRepository : GeneralRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(LeaveManagementDbContext context) : base(context)
        {
        }
    }
}
