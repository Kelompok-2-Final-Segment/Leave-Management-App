using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class add_nik_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("2cc91152-831d-4e00-a07b-2efdf0124f09"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("5a545ebf-fe98-40d2-90fd-5afdb46513f3"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("69914a27-f3fe-4f72-be96-e9df99cc0b7b"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("837c1e43-f87f-4bb8-b304-7dba0554f768"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("e47b1966-77d8-48b5-880a-801f515dbb15"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("2c2e6f0a-3fba-4e9f-bebe-8e7d32ab93f4"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("7c3fcf3e-a732-4126-855a-ccdac67b3d3e"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("b87825f5-ac5f-4b82-844e-09d56df95418"));

            migrationBuilder.AddColumn<string>(
                name: "nik",
                table: "tb_m_employees",
                type: "nchar(6)",
                nullable: false,
                defaultValue: "");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "nik",
                table: "tb_m_employees");

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
        }
    }
}
