using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class DepartmentRepository : GeneralRepository<Department> , IDepartmentRepository
    {
        public DepartmentRepository(LeaveManagementDbContext context) : base(context)
        {
        }
    }
}
