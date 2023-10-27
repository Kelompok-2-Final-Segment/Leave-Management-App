using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class add_column_female_only_and_remarks_hr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "remarks",
                table: "tb_m_leaves",
                newName: "remarks_by_manager");

            migrationBuilder.AddColumn<string>(
                name: "remarks_by_HR",
                table: "tb_m_leaves",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "female_only",
                table: "tb_m_leave_types",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "remarks_by_HR",
                table: "tb_m_leaves");

            migrationBuilder.DropColumn(
                name: "female_only",
                table: "tb_m_leave_types");

            migrationBuilder.RenameColumn(
                name: "remarks_by_manager",
                table: "tb_m_leaves",
                newName: "remarks");

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
        }
    }
}
