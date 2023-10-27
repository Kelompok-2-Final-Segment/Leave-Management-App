using API.Contracts;
using API.Data;
using API.Models;

namespace API.Repositories
{
    public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
    {
        private readonly LeaveManagementDbContext _context;
        public EmployeeRepository(LeaveManagementDbContext context) : base(context)
        {
            _context = context;
        }
        public string? GetLastNik()
        {
            return _context.Set<Employee>().OrderByDescending(e => e.NIK).FirstOrDefault()?.NIK;
        }
        public Employee? GetByEmail(string email)
        {
            return _context.Set<Employee>().FirstOrDefault(e => e.Email == email);
        }

        public Employee? GetByNIK(string nik)
        {
            return _context.Set<Employee>().FirstOrDefault(e => e.NIK == nik);
        }
    }
}
