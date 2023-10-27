using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class add_column_in_leaves_and_cardinality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_leave_balances_tb_m_employees_guid",
                table: "tb_m_leave_balances");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_leave_balances_leave_type_guid",
                table: "tb_m_leave_balances");

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("10a8e9f2-8b32-49c0-a940-3c7f5879ff24"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("110cbbaf-e0c6-4463-b1a9-b3180ad389e0"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("423ab16f-4850-40d3-a589-efe3acdb4b1f"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("747009cc-7acb-4bd8-a4de-bf32d3af66f0"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("dffedc41-3a30-45b4-b169-7295f6fa6eef"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("26ad102f-3d54-46e5-a0aa-38010fbfaa07"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("b50bf412-1d29-48ad-aa7a-a1f9fec291f0"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("f1d8b84c-1952-48d9-abde-04fdd1caa41f"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("9e3ab8ed-49c3-4b38-bc77-f3c2a7ef556f"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("e52ee302-1c37-4176-baeb-88ac35677c74"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("fb0fa01d-4f05-4b28-a442-6cd4448afd3b"));

            migrationBuilder.DropColumn(
                name: "balance",
                table: "tb_m_leave_balances");

            migrationBuilder.AddColumn<int>(
                name: "balance",
                table: "tb_m_leave_types",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "employee_guid",
                table: "tb_m_leave_balances",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "is_available",
                table: "tb_m_leave_balances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "tb_m_departments",
                columns: new[] { "guid", "created_date", "manager_guid", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("0d18ff80-4a7d-40aa-bc26-a577b1cd0c40"), new DateTime(2023, 10, 27, 9, 36, 55, 122, DateTimeKind.Local).AddTicks(1470), null, new DateTime(2023, 10, 27, 9, 36, 55, 122, DateTimeKind.Local).AddTicks(1471), "Finance" },
                    { new Guid("442080ef-4449-4734-a46a-cc48e5bc8c40"), new DateTime(2023, 10, 27, 9, 36, 55, 122, DateTimeKind.Local).AddTicks(1481), null, new DateTime(2023, 10, 27, 9, 36, 55, 122, DateTimeKind.Local).AddTicks(1481), "Customer Support" },
                    { new Guid("60aa5069-8249-4ca6-9cd4-8c5709b73a06"), new DateTime(2023, 10, 27, 9, 36, 55, 122, DateTimeKind.Local).AddTicks(1473), null, new DateTime(2023, 10, 27, 9, 36, 55, 122, DateTimeKind.Local).AddTicks(1474), "HR" },
                    { new Guid("849ab0b0-5fd3-4121-b8ce-97f8abf69740"), new DateTime(2023, 10, 27, 9, 36, 55, 122, DateTimeKind.Local).AddTicks(1476), null, new DateTime(2023, 10, 27, 9, 36, 55, 122, DateTimeKind.Local).AddTicks(1476), "IT" },
                    { new Guid("9dea95bc-3a90-4e99-b485-88967f2d1010"), new DateTime(2023, 10, 27, 9, 36, 55, 122, DateTimeKind.Local).AddTicks(1478), null, new DateTime(2023, 10, 27, 9, 36, 55, 122, DateTimeKind.Local).AddTicks(1479), "Sales and Marketing" }
                });

            migrationBuilder.InsertData(
                table: "tb_m_leave_types",
                columns: new[] { "guid", "balance", "created_date", "max_duration", "min_duration", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("4dbb2d22-2635-4ed2-9fa9-11cd4bb0b308"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual Leave" },
                    { new Guid("6d2ba83a-c0d4-487b-9d45-b3ed0f9658c3"), 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sick Leave" },
                    { new Guid("a8a8e67c-0ddd-422c-a453-a79b9e98c83a"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Personal Leave" }
                });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("39c4a47e-b314-4e11-a18d-25443f312455"), new DateTime(2023, 10, 27, 9, 36, 55, 122, DateTimeKind.Local).AddTicks(1316), new DateTime(2023, 10, 27, 9, 36, 55, 122, DateTimeKind.Local).AddTicks(1323), "Manager" },
                    { new Guid("b485fff0-67fd-4ae4-9c56-18c0468398dc"), new DateTime(2023, 10, 27, 9, 36, 55, 122, DateTimeKind.Local).AddTicks(1325), new DateTime(2023, 10, 27, 9, 36, 55, 122, DateTimeKind.Local).AddTicks(1326), "Staff" },
                    { new Guid("c3b83eb3-4166-49d4-ac6e-335e9ab63129"), new DateTime(2023, 10, 27, 9, 36, 55, 122, DateTimeKind.Local).AddTicks(1328), new DateTime(2023, 10, 27, 9, 36, 55, 122, DateTimeKind.Local).AddTicks(1328), "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_roles_name",
                table: "tb_m_roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_leave_types_name",
                table: "tb_m_leave_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_leave_balances_employee_guid",
                table: "tb_m_leave_balances",
                column: "employee_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_leave_balances_leave_type_guid",
                table: "tb_m_leave_balances",
                column: "leave_type_guid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employees_nik",
                table: "tb_m_employees",
                column: "nik",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_departments_name",
                table: "tb_m_departments",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_leave_balances_tb_m_employees_employee_guid",
                table: "tb_m_leave_balances",
                column: "employee_guid",
                principalTable: "tb_m_employees",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_leave_balances_tb_m_employees_employee_guid",
                table: "tb_m_leave_balances");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_roles_name",
                table: "tb_m_roles");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_leave_types_name",
                table: "tb_m_leave_types");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_leave_balances_employee_guid",
                table: "tb_m_leave_balances");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_leave_balances_leave_type_guid",
                table: "tb_m_leave_balances");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_employees_nik",
                table: "tb_m_employees");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_departments_name",
                table: "tb_m_departments");

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("0d18ff80-4a7d-40aa-bc26-a577b1cd0c40"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("442080ef-4449-4734-a46a-cc48e5bc8c40"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("60aa5069-8249-4ca6-9cd4-8c5709b73a06"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("849ab0b0-5fd3-4121-b8ce-97f8abf69740"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("9dea95bc-3a90-4e99-b485-88967f2d1010"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("4dbb2d22-2635-4ed2-9fa9-11cd4bb0b308"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("6d2ba83a-c0d4-487b-9d45-b3ed0f9658c3"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("a8a8e67c-0ddd-422c-a453-a79b9e98c83a"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("39c4a47e-b314-4e11-a18d-25443f312455"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("b485fff0-67fd-4ae4-9c56-18c0468398dc"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("c3b83eb3-4166-49d4-ac6e-335e9ab63129"));

            migrationBuilder.DropColumn(
                name: "balance",
                table: "tb_m_leave_types");

            migrationBuilder.DropColumn(
                name: "employee_guid",
                table: "tb_m_leave_balances");

            migrationBuilder.DropColumn(
                name: "is_available",
                table: "tb_m_leave_balances");

            migrationBuilder.AddColumn<int>(
                name: "balance",
                table: "tb_m_leave_balances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "tb_m_departments",
                columns: new[] { "guid", "created_date", "manager_guid", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("10a8e9f2-8b32-49c0-a940-3c7f5879ff24"), new DateTime(2023, 10, 26, 15, 12, 45, 759, DateTimeKind.Local).AddTicks(1102), null, new DateTime(2023, 10, 26, 15, 12, 45, 759, DateTimeKind.Local).AddTicks(1103), "HR" },
                    { new Guid("110cbbaf-e0c6-4463-b1a9-b3180ad389e0"), new DateTime(2023, 10, 26, 15, 12, 45, 759, DateTimeKind.Local).AddTicks(1116), null, new DateTime(2023, 10, 26, 15, 12, 45, 759, DateTimeKind.Local).AddTicks(1117), "Customer Support" },
                    { new Guid("423ab16f-4850-40d3-a589-efe3acdb4b1f"), new DateTime(2023, 10, 26, 15, 12, 45, 759, DateTimeKind.Local).AddTicks(1106), null, new DateTime(2023, 10, 26, 15, 12, 45, 759, DateTimeKind.Local).AddTicks(1108), "IT" },
                    { new Guid("747009cc-7acb-4bd8-a4de-bf32d3af66f0"), new DateTime(2023, 10, 26, 15, 12, 45, 759, DateTimeKind.Local).AddTicks(1077), null, new DateTime(2023, 10, 26, 15, 12, 45, 759, DateTimeKind.Local).AddTicks(1078), "Finance" },
                    { new Guid("dffedc41-3a30-45b4-b169-7295f6fa6eef"), new DateTime(2023, 10, 26, 15, 12, 45, 759, DateTimeKind.Local).AddTicks(1112), null, new DateTime(2023, 10, 26, 15, 12, 45, 759, DateTimeKind.Local).AddTicks(1114), "Sales and Marketing" }
                });

            migrationBuilder.InsertData(
                table: "tb_m_leave_types",
                columns: new[] { "guid", "created_date", "max_duration", "min_duration", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("26ad102f-3d54-46e5-a0aa-38010fbfaa07"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sick Leave" },
                    { new Guid("b50bf412-1d29-48ad-aa7a-a1f9fec291f0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Personal Leave" },
                    { new Guid("f1d8b84c-1952-48d9-abde-04fdd1caa41f"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual Leave" }
                });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("9e3ab8ed-49c3-4b38-bc77-f3c2a7ef556f"), new DateTime(2023, 10, 26, 15, 12, 45, 759, DateTimeKind.Local).AddTicks(789), new DateTime(2023, 10, 26, 15, 12, 45, 759, DateTimeKind.Local).AddTicks(790), "Admin" },
                    { new Guid("e52ee302-1c37-4176-baeb-88ac35677c74"), new DateTime(2023, 10, 26, 15, 12, 45, 759, DateTimeKind.Local).AddTicks(771), new DateTime(2023, 10, 26, 15, 12, 45, 759, DateTimeKind.Local).AddTicks(782), "Manager" },
                    { new Guid("fb0fa01d-4f05-4b28-a442-6cd4448afd3b"), new DateTime(2023, 10, 26, 15, 12, 45, 759, DateTimeKind.Local).AddTicks(785), new DateTime(2023, 10, 26, 15, 12, 45, 759, DateTimeKind.Local).AddTicks(786), "Staff" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_leave_balances_leave_type_guid",
                table: "tb_m_leave_balances",
                column: "leave_type_guid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_leave_balances_tb_m_employees_guid",
                table: "tb_m_leave_balances",
                column: "guid",
                principalTable: "tb_m_employees",
                principalColumn: "guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
