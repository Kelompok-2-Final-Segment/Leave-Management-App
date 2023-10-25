using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class initial_migrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_departments",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    manager_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_departments", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_leave_types",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    min_duration = table.Column<int>(type: "int", nullable: false),
                    max_duration = table.Column<int>(type: "int", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_leave_types", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_roles",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_roles", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_employees",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hiring_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    department_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_employees", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_m_employees_tb_m_departments_department_guid",
                        column: x => x.department_guid,
                        principalTable: "tb_m_departments",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_accounts",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    otp = table.Column<int>(type: "int", nullable: false),
                    is_used = table.Column<bool>(type: "bit", nullable: false),
                    expired_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_accounts", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_m_accounts_tb_m_employees_guid",
                        column: x => x.guid,
                        principalTable: "tb_m_employees",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_leave_balances",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    balance = table.Column<int>(type: "int", nullable: false),
                    used_balance = table.Column<int>(type: "int", nullable: false),
                    leave_type_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_leave_balances", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_m_leave_balances_tb_m_employees_guid",
                        column: x => x.guid,
                        principalTable: "tb_m_employees",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_leave_balances_tb_m_leave_types_leave_type_guid",
                        column: x => x.leave_type_guid,
                        principalTable: "tb_m_leave_types",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_leaves",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    start_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employee_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    leave_type_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_leaves", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_m_leaves_tb_m_employees_employee_guid",
                        column: x => x.employee_guid,
                        principalTable: "tb_m_employees",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_leaves_tb_m_leave_types_leave_type_guid",
                        column: x => x.leave_type_guid,
                        principalTable: "tb_m_leave_types",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_account_roles",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    account_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    role_guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_account_roles", x => x.guid);
                    table.ForeignKey(
                        name: "FK_tb_m_account_roles_tb_m_accounts_account_guid",
                        column: x => x.account_guid,
                        principalTable: "tb_m_accounts",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_account_roles_tb_m_roles_role_guid",
                        column: x => x.role_guid,
                        principalTable: "tb_m_roles",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tb_m_departments",
                columns: new[] { "guid", "created_date", "manager_guid", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("2cc91152-831d-4e00-a07b-2efdf0124f09"), new DateTime(2023, 10, 25, 15, 44, 21, 101, DateTimeKind.Local).AddTicks(6267), null, new DateTime(2023, 10, 25, 15, 44, 21, 101, DateTimeKind.Local).AddTicks(6268), "HR" },
                    { new Guid("5a545ebf-fe98-40d2-90fd-5afdb46513f3"), new DateTime(2023, 10, 25, 15, 44, 21, 101, DateTimeKind.Local).AddTicks(6295), null, new DateTime(2023, 10, 25, 15, 44, 21, 101, DateTimeKind.Local).AddTicks(6295), "Sales and Marketing" },
                    { new Guid("69914a27-f3fe-4f72-be96-e9df99cc0b7b"), new DateTime(2023, 10, 25, 15, 44, 21, 101, DateTimeKind.Local).AddTicks(6271), null, new DateTime(2023, 10, 25, 15, 44, 21, 101, DateTimeKind.Local).AddTicks(6272), "IT" },
                    { new Guid("837c1e43-f87f-4bb8-b304-7dba0554f768"), new DateTime(2023, 10, 25, 15, 44, 21, 101, DateTimeKind.Local).AddTicks(6262), null, new DateTime(2023, 10, 25, 15, 44, 21, 101, DateTimeKind.Local).AddTicks(6263), "Finance" },
                    { new Guid("e47b1966-77d8-48b5-880a-801f515dbb15"), new DateTime(2023, 10, 25, 15, 44, 21, 101, DateTimeKind.Local).AddTicks(6299), null, new DateTime(2023, 10, 25, 15, 44, 21, 101, DateTimeKind.Local).AddTicks(6300), "Customer Support" }
                });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("2c2e6f0a-3fba-4e9f-bebe-8e7d32ab93f4"), new DateTime(2023, 10, 25, 15, 44, 21, 101, DateTimeKind.Local).AddTicks(5829), new DateTime(2023, 10, 25, 15, 44, 21, 101, DateTimeKind.Local).AddTicks(5830), "Employee" },
                    { new Guid("7c3fcf3e-a732-4126-855a-ccdac67b3d3e"), new DateTime(2023, 10, 25, 15, 44, 21, 101, DateTimeKind.Local).AddTicks(5857), new DateTime(2023, 10, 25, 15, 44, 21, 101, DateTimeKind.Local).AddTicks(5894), "HR" },
                    { new Guid("b87825f5-ac5f-4b82-844e-09d56df95418"), new DateTime(2023, 10, 25, 15, 44, 21, 101, DateTimeKind.Local).AddTicks(5812), new DateTime(2023, 10, 25, 15, 44, 21, 101, DateTimeKind.Local).AddTicks(5826), "Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_account_roles_account_guid",
                table: "tb_m_account_roles",
                column: "account_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_account_roles_role_guid",
                table: "tb_m_account_roles",
                column: "role_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_department_guid",
                table: "tb_m_employees",
                column: "department_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_email",
                table: "tb_m_employees",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_phone_number",
                table: "tb_m_employees",
                column: "phone_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_leave_balances_leave_type_guid",
                table: "tb_m_leave_balances",
                column: "leave_type_guid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_leaves_employee_guid",
                table: "tb_m_leaves",
                column: "employee_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_leaves_leave_type_guid",
                table: "tb_m_leaves",
                column: "leave_type_guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_account_roles");

            migrationBuilder.DropTable(
                name: "tb_m_leave_balances");

            migrationBuilder.DropTable(
                name: "tb_m_leaves");

            migrationBuilder.DropTable(
                name: "tb_m_accounts");

            migrationBuilder.DropTable(
                name: "tb_m_roles");

            migrationBuilder.DropTable(
                name: "tb_m_leave_types");

            migrationBuilder.DropTable(
                name: "tb_m_employees");

            migrationBuilder.DropTable(
                name: "tb_m_departments");
        }
    }
}
