﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(LeaveManagementDbContext))]
    partial class LeaveManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ExpiredTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("expired_time");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit")
                        .HasColumnName("is_used");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<int>("OTP")
                        .HasColumnType("int")
                        .HasColumnName("otp");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.HasKey("Guid");

                    b.ToTable("tb_m_accounts");
                });

            modelBuilder.Entity("API.Models.AccountRole", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<Guid>("AccountGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("account_guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<Guid>("RoleGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("role_guid");

                    b.HasKey("Guid");

                    b.HasIndex("AccountGuid");

                    b.HasIndex("RoleGuid");

                    b.ToTable("tb_m_account_roles");
                });

            modelBuilder.Entity("API.Models.Department", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<Guid?>("ManagerGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("manager_guid");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Guid");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tb_m_departments");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("2054b3d1-2734-4848-881b-96e063410746"),
                            CreatedDate = new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8154),
                            ModifiedDate = new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8155),
                            Name = "Finance"
                        },
                        new
                        {
                            Guid = new Guid("a4498431-7322-46be-812c-b9d47c8a82df"),
                            CreatedDate = new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8157),
                            ModifiedDate = new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8158),
                            Name = "HR"
                        },
                        new
                        {
                            Guid = new Guid("4993b02b-3bdf-4f40-9202-a792bdb0c102"),
                            CreatedDate = new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8160),
                            ModifiedDate = new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8161),
                            Name = "IT"
                        },
                        new
                        {
                            Guid = new Guid("f27c04f4-c36d-45be-9275-b9ff2df9fc3f"),
                            CreatedDate = new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8164),
                            ModifiedDate = new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8164),
                            Name = "Sales and Marketing"
                        },
                        new
                        {
                            Guid = new Guid("239297ad-5746-4602-ba84-c1c48d10c4fa"),
                            CreatedDate = new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8167),
                            ModifiedDate = new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8167),
                            Name = "Customer Support"
                        });
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birth_date");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<Guid>("DepartmentGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("department_guid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("first_name");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("gender");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("hiring_date");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("last_name");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("NIK")
                        .IsRequired()
                        .HasColumnType("nchar(6)")
                        .HasColumnName("nik");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("phone_number");

                    b.HasKey("Guid");

                    b.HasIndex("DepartmentGuid");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("NIK")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("tb_m_employees");
                });

            modelBuilder.Entity("API.Models.Leave", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<Guid>("EmployeeGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("employee_guid");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("end_date");

                    b.Property<Guid>("LeaveTypeGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("leave_type_guid");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("RemarksHR")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("remarks_by_HR");

                    b.Property<string>("RemarksManager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("remarks_by_manager");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("start_date");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.HasKey("Guid");

                    b.HasIndex("EmployeeGuid");

                    b.HasIndex("LeaveTypeGuid");

                    b.ToTable("tb_m_leaves");
                });

            modelBuilder.Entity("API.Models.LeaveBalance", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<Guid>("EmployeeGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("employee_guid");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit")
                        .HasColumnName("is_available");

                    b.Property<Guid>("LeaveTypeGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("leave_type_guid");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<int>("UsedBalance")
                        .HasColumnType("int")
                        .HasColumnName("used_balance");

                    b.HasKey("Guid");

                    b.HasIndex("EmployeeGuid");

                    b.HasIndex("LeaveTypeGuid");

                    b.ToTable("tb_m_leave_balances");
                });

            modelBuilder.Entity("API.Models.LeaveType", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<int>("Balance")
                        .HasColumnType("int")
                        .HasColumnName("balance");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<bool>("FemaleOnly")
                        .HasColumnType("bit")
                        .HasColumnName("female_only");

                    b.Property<int>("MaxDuration")
                        .HasColumnType("int")
                        .HasColumnName("max_duration");

                    b.Property<int>("MinDuration")
                        .HasColumnType("int")
                        .HasColumnName("min_duration");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Guid");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tb_m_leave_types");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("8fb5dbab-8e7f-4a24-a961-08086cc2c1b9"),
                            Balance = 12,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FemaleOnly = false,
                            MaxDuration = 12,
                            MinDuration = 1,
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Annual Leave"
                        },
                        new
                        {
                            Guid = new Guid("9ea3e8b7-657d-4ca6-9900-04f3ec9b7471"),
                            Balance = 90,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FemaleOnly = false,
                            MaxDuration = 90,
                            MinDuration = 1,
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sick Leave"
                        },
                        new
                        {
                            Guid = new Guid("38cfb695-ccd7-4b15-a85c-156504240d4f"),
                            Balance = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FemaleOnly = false,
                            MaxDuration = 2,
                            MinDuration = 1,
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Personal Leave"
                        });
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Guid");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tb_m_roles");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("00fdad55-c5c3-4c6a-bf08-85280bf09735"),
                            CreatedDate = new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(7900),
                            ModifiedDate = new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(7909),
                            Name = "Manager"
                        },
                        new
                        {
                            Guid = new Guid("461f34c1-b282-49a9-ab96-acc2d5c5b89c"),
                            CreatedDate = new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(7912),
                            ModifiedDate = new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(7913),
                            Name = "Staff"
                        },
                        new
                        {
                            Guid = new Guid("f10cb686-4391-4be1-b9f0-fa687202e960"),
                            CreatedDate = new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(7930),
                            ModifiedDate = new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(7931),
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.HasOne("API.Models.Employee", "Employee")
                        .WithOne("Account")
                        .HasForeignKey("API.Models.Account", "Guid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("API.Models.AccountRole", b =>
                {
                    b.HasOne("API.Models.Account", "Account")
                        .WithMany("AccountRoles")
                        .HasForeignKey("AccountGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Role", "Role")
                        .WithMany("AccountRoles")
                        .HasForeignKey("RoleGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.HasOne("API.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("API.Models.Leave", b =>
                {
                    b.HasOne("API.Models.Employee", "Employee")
                        .WithMany("Leaves")
                        .HasForeignKey("EmployeeGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.LeaveType", "LeaveType")
                        .WithMany("Leaves")
                        .HasForeignKey("LeaveTypeGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("LeaveType");
                });

            modelBuilder.Entity("API.Models.LeaveBalance", b =>
                {
                    b.HasOne("API.Models.Employee", "Employee")
                        .WithMany("LeaveBalances")
                        .HasForeignKey("EmployeeGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.LeaveType", "LeaveType")
                        .WithMany("LeaveBalances")
                        .HasForeignKey("LeaveTypeGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("LeaveType");
                });

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("API.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("LeaveBalances");

                    b.Navigation("Leaves");
                });

            modelBuilder.Entity("API.Models.LeaveType", b =>
                {
                    b.Navigation("LeaveBalances");

                    b.Navigation("Leaves");
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Navigation("AccountRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
