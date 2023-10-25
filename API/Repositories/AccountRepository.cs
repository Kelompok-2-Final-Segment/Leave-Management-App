using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class AccountRepository : GeneralRepository<Account>, IAccountRepository
    {
        private readonly LeaveManagementDbContext _context;
        public AccountRepository(LeaveManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public LeaveManagementDbContext GetContext()
        {
            return _context;
        }
    }

}
