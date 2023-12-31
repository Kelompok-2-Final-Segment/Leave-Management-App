﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(LeaveManagementDbContext))]
    [Migration("20231031043647_department_name_changed")]
    partial class department_name_changed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Guid = new Guid("97de1a7a-65bc-4464-aab3-985898a7373a"),
                            CreatedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3265),
                            ModifiedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3268),
                            Name = "Finance"
                        },
                        new
                        {
                            Guid = new Guid("f5279c25-af25-4caf-9d70-e0ed34e7e499"),
                            CreatedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3276),
                            ModifiedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3278),
                            Name = "Marketing"
                        },
                        new
                        {
                            Guid = new Guid("4c53c005-28ba-4e61-ad58-4357a22d5538"),
                            CreatedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3284),
                            ModifiedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3286),
                            Name = "Operational"
                        },
                        new
                        {
                            Guid = new Guid("d9a87401-f8be-403e-baa5-e8418dc95403"),
                            CreatedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3291),
                            ModifiedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3293),
                            Name = "Information Technology"
                        },
                        new
                        {
                            Guid = new Guid("c2e51796-f7b8-40d4-bff4-b4d8cf5a1b6a"),
                            CreatedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3316),
                            ModifiedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3320),
                            Name = "Legal"
                        },
                        new
                        {
                            Guid = new Guid("6c9d8775-d7d1-4bca-8eae-c90924f3ecb6"),
                            CreatedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3325),
                            ModifiedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3328),
                            Name = "Public Relation"
                        },
                        new
                        {
                            Guid = new Guid("9a77528c-938c-4db7-8004-cf54c4d90131"),
                            CreatedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3330),
                            ModifiedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3331),
                            Name = "Human Resource"
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

                    b.Property<string>("Document")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("document");

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

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("remarks");

                    b.HasKey("Guid");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tb_m_leave_types");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("b8e8bcd2-9710-46f8-bab9-083dc6f083a9"),
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
                            Guid = new Guid("a23c26db-15a0-4a46-9faa-906398ceee1b"),
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
                            Guid = new Guid("c78b3367-63db-4fdd-9355-de7233e56832"),
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
                            Guid = new Guid("ef3563cb-a8b3-4048-9d75-5f07bc0592b7"),
                            CreatedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(2751),
                            ModifiedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(2761),
                            Name = "Manager"
                        },
                        new
                        {
                            Guid = new Guid("4fdac55a-1304-4343-aa5a-1341ee697caa"),
                            CreatedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(2765),
                            ModifiedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(2767),
                            Name = "Staff"
                        },
                        new
                        {
                            Guid = new Guid("21fc246e-8cce-4fbd-afa4-2112d9db4e93"),
                            CreatedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(2770),
                            ModifiedDate = new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(2772),
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
