using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class LeaveManagementDbContext : DbContext
    {
        public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options) : base(options)
        {
           
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<Role> Roles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasIndex(e => e.PhoneNumber).IsUnique();
            modelBuilder.Entity<Employee>().HasIndex(e => e.Email).IsUnique();

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Account)
                .WithOne(a => a.Employee)
                .HasForeignKey<Account>(a => a.Guid);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountRoles)
                .WithOne(ar => ar.Account)
                .HasForeignKey(ar => ar.AccountGuid);

            modelBuilder.Entity<Role>()        
                .HasMany(r => r.AccountRoles)
                .WithOne(ar => ar.Role)
                .HasForeignKey(ar => ar.RoleGuid);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Leaves)
                .WithOne(l => l.Employee)
                .HasForeignKey(l => l.EmployeeGuid);

            modelBuilder.Entity<Leave>()
                .HasOne(l => l.LeaveType)
                .WithMany(lt => lt.Leaves)
                .HasForeignKey(l => l.LeaveTypeGuid);

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Guid= new Guid(), Gender= 0, FirstName= "user", LastName="1", Email="user1@mail.com", HiringDate = new DateTime(2020, 10, 1) ,BirthDate = new DateTime(2000, 04, 1) , CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now, PhoneNumber = "0891351849134"});
        }
    }
}
