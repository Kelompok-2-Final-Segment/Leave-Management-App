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
    [Migration("20231102151156_type_cuti")]
    partial class type_cuti
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
                            Guid = new Guid("72cc7df3-8f95-4469-b543-44e9d11a7f33"),
                            CreatedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2569),
                            ModifiedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2570),
                            Name = "Finance"
                        },
                        new
                        {
                            Guid = new Guid("2e7835fe-8b13-4cc2-92b7-9957283104dc"),
                            CreatedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2572),
                            ModifiedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2573),
                            Name = "Marketing"
                        },
                        new
                        {
                            Guid = new Guid("d52e87ef-9b07-4b5e-8f72-a4c56136eb6b"),
                            CreatedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2575),
                            ModifiedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2576),
                            Name = "Operational"
                        },
                        new
                        {
                            Guid = new Guid("496ae9c5-dcec-4d99-a364-5aafa74fa344"),
                            CreatedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2578),
                            ModifiedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2579),
                            Name = "Information Technology"
                        },
                        new
                        {
                            Guid = new Guid("e954ebef-cd1d-4c32-8888-acda37d1f5cc"),
                            CreatedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2581),
                            ModifiedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2582),
                            Name = "Legal"
                        },
                        new
                        {
                            Guid = new Guid("cba68096-fcf4-49ce-8830-f1b87e8af203"),
                            CreatedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2584),
                            ModifiedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2585),
                            Name = "Public Relation"
                        },
                        new
                        {
                            Guid = new Guid("e6e36a1b-250f-473f-85c0-3399e4a9f6dd"),
                            CreatedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2587),
                            ModifiedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2588),
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
                            Guid = new Guid("ce2b62ce-f0f1-4cc0-81b6-617136bc4b13"),
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
                            Guid = new Guid("d9e55593-553f-41dd-a38e-c72701b7b445"),
                            Balance = 7,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FemaleOnly = false,
                            MaxDuration = 7,
                            MinDuration = 1,
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Sick Leave"
                        },
                        new
                        {
                            Guid = new Guid("bddbff8c-63e1-481e-8337-16fb1f02a6ec"),
                            Balance = 45,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FemaleOnly = true,
                            MaxDuration = 45,
                            MinDuration = 1,
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Maternity Leave"
                        },
                        new
                        {
                            Guid = new Guid("cb2f3377-0e89-4350-89b8-13694700960c"),
                            Balance = 30,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FemaleOnly = false,
                            MaxDuration = 30,
                            MinDuration = 1,
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Big Leave"
                        },
                        new
                        {
                            Guid = new Guid("64451c9c-35d2-4ff9-8c25-c130f3413c2e"),
                            Balance = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FemaleOnly = true,
                            MaxDuration = 2,
                            MinDuration = 1,
                            ModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Haid Leave"
                        },
                        new
                        {
                            Guid = new Guid("a767e9a9-8afc-4f5a-954b-dd69d5d8892d"),
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
                            Guid = new Guid("b03d48ce-ed44-4bb7-a2bb-9d596b091078"),
                            CreatedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2350),
                            ModifiedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2359),
                            Name = "Manager"
                        },
                        new
                        {
                            Guid = new Guid("de145df1-e121-4b26-a00a-48fa20061e3b"),
                            CreatedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2362),
                            ModifiedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2362),
                            Name = "Staff"
                        },
                        new
                        {
                            Guid = new Guid("52df263e-72a3-4183-98da-b494ad99ea5b"),
                            CreatedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2365),
                            ModifiedDate = new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2366),
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
