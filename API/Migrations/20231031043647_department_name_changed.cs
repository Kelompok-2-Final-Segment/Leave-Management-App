using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class department_name_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("3b27dd3a-b42e-461d-b481-a99fbb72827f"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("43209029-f759-4e03-a8c3-6cb778a09254"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("7823f593-d515-49bb-944e-68602520c6ce"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("93cb3cb7-4b6d-4d8e-bc77-285a8143767e"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("e4cc504f-f965-4116-b575-c55303982e47"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("1a625544-d73b-4690-a44f-2d9cd5f32204"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("62af5838-4962-4faa-9815-0ddd8d636965"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("74ed5a60-0732-474c-a0a6-c46a77f03bcd"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("93b386dc-0ebc-4bed-98de-5e3056e04cd9"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("dbd73bf2-5c4f-4b61-afcc-0a1d4a3ea5ee"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("e2880b08-47a1-4e87-a027-de1f5ec7b6ac"));

            migrationBuilder.InsertData(
                table: "tb_m_departments",
                columns: new[] { "guid", "created_date", "manager_guid", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("4c53c005-28ba-4e61-ad58-4357a22d5538"), new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3284), null, new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3286), "Operational" },
                    { new Guid("6c9d8775-d7d1-4bca-8eae-c90924f3ecb6"), new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3325), null, new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3328), "Public Relation" },
                    { new Guid("97de1a7a-65bc-4464-aab3-985898a7373a"), new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3265), null, new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3268), "Finance" },
                    { new Guid("9a77528c-938c-4db7-8004-cf54c4d90131"), new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3330), null, new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3331), "Human Resource" },
                    { new Guid("c2e51796-f7b8-40d4-bff4-b4d8cf5a1b6a"), new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3316), null, new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3320), "Legal" },
                    { new Guid("d9a87401-f8be-403e-baa5-e8418dc95403"), new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3291), null, new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3293), "Information Technology" },
                    { new Guid("f5279c25-af25-4caf-9d70-e0ed34e7e499"), new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3276), null, new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(3278), "Marketing" }
                });

            migrationBuilder.InsertData(
                table: "tb_m_leave_types",
                columns: new[] { "guid", "balance", "created_date", "female_only", "max_duration", "min_duration", "modified_date", "name", "remarks" },
                values: new object[,]
                {
                    { new Guid("a23c26db-15a0-4a46-9faa-906398ceee1b"), 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 90, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sick Leave", null },
                    { new Guid("b8e8bcd2-9710-46f8-bab9-083dc6f083a9"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 12, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual Leave", null },
                    { new Guid("c78b3367-63db-4fdd-9355-de7233e56832"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Personal Leave", null }
                });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("21fc246e-8cce-4fbd-afa4-2112d9db4e93"), new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(2770), new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(2772), "Admin" },
                    { new Guid("4fdac55a-1304-4343-aa5a-1341ee697caa"), new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(2765), new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(2767), "Staff" },
                    { new Guid("ef3563cb-a8b3-4048-9d75-5f07bc0592b7"), new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(2751), new DateTime(2023, 10, 31, 11, 36, 46, 75, DateTimeKind.Local).AddTicks(2761), "Manager" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("4c53c005-28ba-4e61-ad58-4357a22d5538"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("6c9d8775-d7d1-4bca-8eae-c90924f3ecb6"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("97de1a7a-65bc-4464-aab3-985898a7373a"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("9a77528c-938c-4db7-8004-cf54c4d90131"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("c2e51796-f7b8-40d4-bff4-b4d8cf5a1b6a"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("d9a87401-f8be-403e-baa5-e8418dc95403"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("f5279c25-af25-4caf-9d70-e0ed34e7e499"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("a23c26db-15a0-4a46-9faa-906398ceee1b"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("b8e8bcd2-9710-46f8-bab9-083dc6f083a9"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("c78b3367-63db-4fdd-9355-de7233e56832"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("21fc246e-8cce-4fbd-afa4-2112d9db4e93"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("4fdac55a-1304-4343-aa5a-1341ee697caa"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("ef3563cb-a8b3-4048-9d75-5f07bc0592b7"));

            migrationBuilder.InsertData(
                table: "tb_m_departments",
                columns: new[] { "guid", "created_date", "manager_guid", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("3b27dd3a-b42e-461d-b481-a99fbb72827f"), new DateTime(2023, 10, 28, 20, 47, 55, 363, DateTimeKind.Local).AddTicks(6915), null, new DateTime(2023, 10, 28, 20, 47, 55, 363, DateTimeKind.Local).AddTicks(6915), "Sales and Marketing" },
                    { new Guid("43209029-f759-4e03-a8c3-6cb778a09254"), new DateTime(2023, 10, 28, 20, 47, 55, 363, DateTimeKind.Local).AddTicks(6912), null, new DateTime(2023, 10, 28, 20, 47, 55, 363, DateTimeKind.Local).AddTicks(6913), "IT" },
                    { new Guid("7823f593-d515-49bb-944e-68602520c6ce"), new DateTime(2023, 10, 28, 20, 47, 55, 363, DateTimeKind.Local).AddTicks(6909), null, new DateTime(2023, 10, 28, 20, 47, 55, 363, DateTimeKind.Local).AddTicks(6910), "HR" },
                    { new Guid("93cb3cb7-4b6d-4d8e-bc77-285a8143767e"), new DateTime(2023, 10, 28, 20, 47, 55, 363, DateTimeKind.Local).AddTicks(6890), null, new DateTime(2023, 10, 28, 20, 47, 55, 363, DateTimeKind.Local).AddTicks(6890), "Finance" },
                    { new Guid("e4cc504f-f965-4116-b575-c55303982e47"), new DateTime(2023, 10, 28, 20, 47, 55, 363, DateTimeKind.Local).AddTicks(6917), null, new DateTime(2023, 10, 28, 20, 47, 55, 363, DateTimeKind.Local).AddTicks(6918), "Customer Support" }
                });

            migrationBuilder.InsertData(
                table: "tb_m_leave_types",
                columns: new[] { "guid", "balance", "created_date", "female_only", "max_duration", "min_duration", "modified_date", "name", "remarks" },
                values: new object[,]
                {
                    { new Guid("1a625544-d73b-4690-a44f-2d9cd5f32204"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Personal Leave", null },
                    { new Guid("62af5838-4962-4faa-9815-0ddd8d636965"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 12, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual Leave", null },
                    { new Guid("74ed5a60-0732-474c-a0a6-c46a77f03bcd"), 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 90, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sick Leave", null }
                });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("93b386dc-0ebc-4bed-98de-5e3056e04cd9"), new DateTime(2023, 10, 28, 20, 47, 55, 363, DateTimeKind.Local).AddTicks(6742), new DateTime(2023, 10, 28, 20, 47, 55, 363, DateTimeKind.Local).AddTicks(6742), "Staff" },
                    { new Guid("dbd73bf2-5c4f-4b61-afcc-0a1d4a3ea5ee"), new DateTime(2023, 10, 28, 20, 47, 55, 363, DateTimeKind.Local).AddTicks(6731), new DateTime(2023, 10, 28, 20, 47, 55, 363, DateTimeKind.Local).AddTicks(6740), "Manager" },
                    { new Guid("e2880b08-47a1-4e87-a027-de1f5ec7b6ac"), new DateTime(2023, 10, 28, 20, 47, 55, 363, DateTimeKind.Local).AddTicks(6744), new DateTime(2023, 10, 28, 20, 47, 55, 363, DateTimeKind.Local).AddTicks(6745), "Admin" }
                });
        }
    }
}
