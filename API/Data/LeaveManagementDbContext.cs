using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class LeaveManagementDbContext : DbContext
    {
        public LeaveManagementDbContext(DbContextOptions<LeaveManagementDbContext> options) : base(options)
        { }

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
            modelBuilder.Entity<Employee>().HasIndex(e => e.NIK).IsUnique();
            modelBuilder.Entity<Department>().HasIndex(d => d.Name).IsUnique();
            modelBuilder.Entity<Role>().HasIndex(r => r.Name).IsUnique();
            modelBuilder.Entity<LeaveType>().HasIndex(lt => lt.Name).IsUnique();

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

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.LeaveBalances)
                .WithOne(lb => lb.Employee)
                .HasForeignKey(lb => lb.EmployeeGuid);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentGuid);

            modelBuilder.Entity<Leave>()
                .HasOne(l => l.LeaveType)
                .WithMany(lt => lt.Leaves)
                .HasForeignKey(l => l.LeaveTypeGuid);

            modelBuilder.Entity<LeaveType>()
                .HasMany(lt => lt.LeaveBalances)
                .WithOne(lb => lb.LeaveType)
                .HasForeignKey(lb => lb.LeaveTypeGuid);

            modelBuilder.Entity<Role>().HasData(
                new Role { Guid = Guid.NewGuid(), Name = "Manager", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                new Role { Guid = Guid.NewGuid(), Name = "Staff", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                new Role { Guid = Guid.NewGuid(), Name = "Admin", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now }
                );

            modelBuilder.Entity<Department>().HasData(
                new Department { Guid = Guid.NewGuid(), Name = "Finance", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },

                new Department { Guid = Guid.NewGuid(), Name = "HR", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },

                new Department { Guid = Guid.NewGuid(), Name = "IT", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },

                new Department { Guid = Guid.NewGuid(), Name = "Sales and Marketing", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },

                new Department { Guid = Guid.NewGuid(), Name = "Customer Support", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now }
                );

            modelBuilder.Entity<LeaveType>().HasData(
                new LeaveType { Guid = Guid.NewGuid(), Name = "Annual Leave", Balance = 12, FemaleOnly = false, MaxDuration = 12, MinDuration = 1 },
                new LeaveType { Guid = Guid.NewGuid(), Name = "Sick Leave", Balance = 90, FemaleOnly = false, MaxDuration = 90, MinDuration = 1 },
                new LeaveType { Guid = Guid.NewGuid(), Name = "Personal Leave", Balance = 2, FemaleOnly = false, MaxDuration = 2, MinDuration = 1 }
                );
        }
    }
}
