using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class RoleRepository : GeneralRepository<Role>, IRoleRepository
    {
        private readonly LeaveManagementDbContext _context;
        public RoleRepository(LeaveManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public Guid? GetRoleGuid(string roleName)
        {
            return _context.Set<Role>().FirstOrDefault(r => r.Name == roleName)?.Guid;
        }

        public string GetRoleName(Guid guid)
        {
            return _context.Set<Role>().FirstOrDefault(r => r.Guid == guid)?.Name;
        }
    }
}
