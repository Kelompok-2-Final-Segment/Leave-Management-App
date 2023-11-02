using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class type_cuti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("2e7835fe-8b13-4cc2-92b7-9957283104dc"), new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2572), null, new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2573), "Marketing" },
                    { new Guid("496ae9c5-dcec-4d99-a364-5aafa74fa344"), new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2578), null, new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2579), "Information Technology" },
                    { new Guid("72cc7df3-8f95-4469-b543-44e9d11a7f33"), new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2569), null, new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2570), "Finance" },
                    { new Guid("cba68096-fcf4-49ce-8830-f1b87e8af203"), new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2584), null, new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2585), "Public Relation" },
                    { new Guid("d52e87ef-9b07-4b5e-8f72-a4c56136eb6b"), new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2575), null, new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2576), "Operational" },
                    { new Guid("e6e36a1b-250f-473f-85c0-3399e4a9f6dd"), new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2587), null, new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2588), "Human Resource" },
                    { new Guid("e954ebef-cd1d-4c32-8888-acda37d1f5cc"), new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2581), null, new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2582), "Legal" }
                });

            migrationBuilder.InsertData(
                table: "tb_m_leave_types",
                columns: new[] { "guid", "balance", "created_date", "female_only", "max_duration", "min_duration", "modified_date", "name", "remarks" },
                values: new object[,]
                {
                    { new Guid("64451c9c-35d2-4ff9-8c25-c130f3413c2e"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Haid Leave", null },
                    { new Guid("a767e9a9-8afc-4f5a-954b-dd69d5d8892d"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Personal Leave", null },
                    { new Guid("bddbff8c-63e1-481e-8337-16fb1f02a6ec"), 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 45, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maternity Leave", null },
                    { new Guid("cb2f3377-0e89-4350-89b8-13694700960c"), 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 30, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Big Leave", null },
                    { new Guid("ce2b62ce-f0f1-4cc0-81b6-617136bc4b13"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 12, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual Leave", null },
                    { new Guid("d9e55593-553f-41dd-a38e-c72701b7b445"), 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 7, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sick Leave", null }
                });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("52df263e-72a3-4183-98da-b494ad99ea5b"), new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2365), new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2366), "Admin" },
                    { new Guid("b03d48ce-ed44-4bb7-a2bb-9d596b091078"), new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2350), new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2359), "Manager" },
                    { new Guid("de145df1-e121-4b26-a00a-48fa20061e3b"), new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2362), new DateTime(2023, 11, 2, 22, 11, 56, 97, DateTimeKind.Local).AddTicks(2362), "Staff" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("2e7835fe-8b13-4cc2-92b7-9957283104dc"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("496ae9c5-dcec-4d99-a364-5aafa74fa344"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("72cc7df3-8f95-4469-b543-44e9d11a7f33"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("cba68096-fcf4-49ce-8830-f1b87e8af203"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("d52e87ef-9b07-4b5e-8f72-a4c56136eb6b"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("e6e36a1b-250f-473f-85c0-3399e4a9f6dd"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("e954ebef-cd1d-4c32-8888-acda37d1f5cc"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("64451c9c-35d2-4ff9-8c25-c130f3413c2e"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("a767e9a9-8afc-4f5a-954b-dd69d5d8892d"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("bddbff8c-63e1-481e-8337-16fb1f02a6ec"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("cb2f3377-0e89-4350-89b8-13694700960c"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("ce2b62ce-f0f1-4cc0-81b6-617136bc4b13"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("d9e55593-553f-41dd-a38e-c72701b7b445"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("52df263e-72a3-4183-98da-b494ad99ea5b"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("b03d48ce-ed44-4bb7-a2bb-9d596b091078"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("de145df1-e121-4b26-a00a-48fa20061e3b"));

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
    }
}
