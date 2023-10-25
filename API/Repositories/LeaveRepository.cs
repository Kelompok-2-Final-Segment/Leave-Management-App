using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class LeaveRepository : GeneralRepository<Leave>, ILeaveRepository
    {
        public LeaveRepository(LeaveManagementDbContext context) : base(context)
        {
        }
    }
}
