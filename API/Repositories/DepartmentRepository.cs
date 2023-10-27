using API.Contracts;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class DepartmentRepository : GeneralRepository<Department>, IDepartmentRepository
    {
        private readonly LeaveManagementDbContext _context;
        public DepartmentRepository(LeaveManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public Guid? GetDepartmentGuid(string departName)
        {
             return _context.Set<Department>().FirstOrDefault(d => d.Name == departName)?.Guid;
        }
    }
}
