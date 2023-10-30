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
    [Migration("20231028065244_add_column_document_leaves")]
    partial class add_column_document_leaves
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
                            Guid = new Guid("51f670a5-5224-424f-af93-0b3570b21ad4"),
                            CreatedDate = new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(486),
                            ModifiedDate = new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(487),
                            Name = "Finance"
                        },
                        new
                        {
                            Guid = new Guid("616d25bd-a291-46e3-9d55-1bce062db50a"),
                            CreatedDate = new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(490),
                            ModifiedDate = new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(491),
                            Name = "HR"
                        },
                        new
                        {
                            Guid = new Guid("ab82e440-47aa-430e-88a8-e350ffcb89c0"),
                            CreatedDate = new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(516),
                            ModifiedDate = new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(517),
                            Name = "IT"
                        },
                        new
                        {
                            Guid = new Guid("b4ddc8bb-a9db-4720-af82-a548bfca5bdd"),
                            CreatedDate = new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(520),
                            ModifiedDate = new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(520),
                            Name = "Sales and Marketing"
                        },
                        new
                        {
                            Guid = new Guid("324c632a-a56c-4bbe-8bd4-988ce6cb0b62"),
                            CreatedDate = new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(524),
                            ModifiedDate = new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(524),
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

                    b.HasKey("Guid");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tb_m_leave_types");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("8ea448b6-de24-49e3-8c86-4012803121f3"),
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
                            Guid = new Guid("582fae54-a156-49f0-9e2a-b32b3362de8c"),
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
                            Guid = new Guid("c07fd904-8eb5-4d8c-88e2-dd32e8654ef0"),
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
                            Guid = new Guid("7258ff1a-43cf-4cb0-b597-c0756f769c87"),
                            CreatedDate = new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(163),
                            ModifiedDate = new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(176),
                            Name = "Manager"
                        },
                        new
                        {
                            Guid = new Guid("8d4f5db3-b939-4cbf-9fb4-fcd96626e549"),
                            CreatedDate = new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(179),
                            ModifiedDate = new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(180),
                            Name = "Staff"
                        },
                        new
                        {
                            Guid = new Guid("ddf11e41-0a3a-41a7-bb9a-296e948b896a"),
                            CreatedDate = new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(183),
                            ModifiedDate = new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(184),
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