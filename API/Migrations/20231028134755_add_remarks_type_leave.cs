using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class add_remarks_type_leave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("324c632a-a56c-4bbe-8bd4-988ce6cb0b62"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("51f670a5-5224-424f-af93-0b3570b21ad4"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("616d25bd-a291-46e3-9d55-1bce062db50a"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("ab82e440-47aa-430e-88a8-e350ffcb89c0"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("b4ddc8bb-a9db-4720-af82-a548bfca5bdd"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("582fae54-a156-49f0-9e2a-b32b3362de8c"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("8ea448b6-de24-49e3-8c86-4012803121f3"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("c07fd904-8eb5-4d8c-88e2-dd32e8654ef0"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("7258ff1a-43cf-4cb0-b597-c0756f769c87"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("8d4f5db3-b939-4cbf-9fb4-fcd96626e549"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("ddf11e41-0a3a-41a7-bb9a-296e948b896a"));

            migrationBuilder.AddColumn<string>(
                name: "remarks",
                table: "tb_m_leave_types",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "remarks",
                table: "tb_m_leave_types");

            migrationBuilder.InsertData(
                table: "tb_m_departments",
                columns: new[] { "guid", "created_date", "manager_guid", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("324c632a-a56c-4bbe-8bd4-988ce6cb0b62"), new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(524), null, new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(524), "Customer Support" },
                    { new Guid("51f670a5-5224-424f-af93-0b3570b21ad4"), new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(486), null, new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(487), "Finance" },
                    { new Guid("616d25bd-a291-46e3-9d55-1bce062db50a"), new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(490), null, new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(491), "HR" },
                    { new Guid("ab82e440-47aa-430e-88a8-e350ffcb89c0"), new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(516), null, new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(517), "IT" },
                    { new Guid("b4ddc8bb-a9db-4720-af82-a548bfca5bdd"), new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(520), null, new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(520), "Sales and Marketing" }
                });

            migrationBuilder.InsertData(
                table: "tb_m_leave_types",
                columns: new[] { "guid", "balance", "created_date", "female_only", "max_duration", "min_duration", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("582fae54-a156-49f0-9e2a-b32b3362de8c"), 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 90, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sick Leave" },
                    { new Guid("8ea448b6-de24-49e3-8c86-4012803121f3"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 12, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual Leave" },
                    { new Guid("c07fd904-8eb5-4d8c-88e2-dd32e8654ef0"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Personal Leave" }
                });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("7258ff1a-43cf-4cb0-b597-c0756f769c87"), new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(163), new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(176), "Manager" },
                    { new Guid("8d4f5db3-b939-4cbf-9fb4-fcd96626e549"), new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(179), new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(180), "Staff" },
                    { new Guid("ddf11e41-0a3a-41a7-bb9a-296e948b896a"), new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(183), new DateTime(2023, 10, 28, 13, 52, 43, 340, DateTimeKind.Local).AddTicks(184), "Admin" }
                });
        }
    }
}
