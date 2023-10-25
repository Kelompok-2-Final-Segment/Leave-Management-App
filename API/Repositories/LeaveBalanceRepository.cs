using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class LeaveBalanceRepository : GeneralRepository<LeaveBalance>, ILeaveBalanceRepository
    {
        public LeaveBalanceRepository(LeaveManagementDbContext context) : base(context)
        {
        }
    }
}
