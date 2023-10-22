using Microsoft.EntityFrameworkCore;

namespace Leave_Management_App.Data
{
    public class LeaveManagementDbContext : DbContext
    {
        public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options) : base(options)
        {
           
        }
    }
}
