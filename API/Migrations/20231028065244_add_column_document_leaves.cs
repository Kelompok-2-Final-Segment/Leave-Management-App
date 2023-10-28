using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class add_column_document_leaves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("2054b3d1-2734-4848-881b-96e063410746"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("239297ad-5746-4602-ba84-c1c48d10c4fa"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("4993b02b-3bdf-4f40-9202-a792bdb0c102"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("a4498431-7322-46be-812c-b9d47c8a82df"));

            migrationBuilder.DeleteData(
                table: "tb_m_departments",
                keyColumn: "guid",
                keyValue: new Guid("f27c04f4-c36d-45be-9275-b9ff2df9fc3f"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("38cfb695-ccd7-4b15-a85c-156504240d4f"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("8fb5dbab-8e7f-4a24-a961-08086cc2c1b9"));

            migrationBuilder.DeleteData(
                table: "tb_m_leave_types",
                keyColumn: "guid",
                keyValue: new Guid("9ea3e8b7-657d-4ca6-9900-04f3ec9b7471"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("00fdad55-c5c3-4c6a-bf08-85280bf09735"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("461f34c1-b282-49a9-ab96-acc2d5c5b89c"));

            migrationBuilder.DeleteData(
                table: "tb_m_roles",
                keyColumn: "guid",
                keyValue: new Guid("f10cb686-4391-4be1-b9f0-fa687202e960"));

            migrationBuilder.AddColumn<string>(
                name: "document",
                table: "tb_m_leaves",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "document",
                table: "tb_m_leaves");

            migrationBuilder.InsertData(
                table: "tb_m_departments",
                columns: new[] { "guid", "created_date", "manager_guid", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("2054b3d1-2734-4848-881b-96e063410746"), new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8154), null, new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8155), "Finance" },
                    { new Guid("239297ad-5746-4602-ba84-c1c48d10c4fa"), new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8167), null, new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8167), "Customer Support" },
                    { new Guid("4993b02b-3bdf-4f40-9202-a792bdb0c102"), new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8160), null, new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8161), "IT" },
                    { new Guid("a4498431-7322-46be-812c-b9d47c8a82df"), new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8157), null, new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8158), "HR" },
                    { new Guid("f27c04f4-c36d-45be-9275-b9ff2df9fc3f"), new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8164), null, new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(8164), "Sales and Marketing" }
                });

            migrationBuilder.InsertData(
                table: "tb_m_leave_types",
                columns: new[] { "guid", "balance", "created_date", "female_only", "max_duration", "min_duration", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("38cfb695-ccd7-4b15-a85c-156504240d4f"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Personal Leave" },
                    { new Guid("8fb5dbab-8e7f-4a24-a961-08086cc2c1b9"), 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 12, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual Leave" },
                    { new Guid("9ea3e8b7-657d-4ca6-9900-04f3ec9b7471"), 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 90, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sick Leave" }
                });

            migrationBuilder.InsertData(
                table: "tb_m_roles",
                columns: new[] { "guid", "created_date", "modified_date", "name" },
                values: new object[,]
                {
                    { new Guid("00fdad55-c5c3-4c6a-bf08-85280bf09735"), new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(7900), new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(7909), "Manager" },
                    { new Guid("461f34c1-b282-49a9-ab96-acc2d5c5b89c"), new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(7912), new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(7913), "Staff" },
                    { new Guid("f10cb686-4391-4be1-b9f0-fa687202e960"), new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(7930), new DateTime(2023, 10, 27, 15, 15, 14, 997, DateTimeKind.Local).AddTicks(7931), "Admin" }
                });
        }
    }
}
