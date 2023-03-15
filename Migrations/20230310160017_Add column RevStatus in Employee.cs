using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class AddcolumnRevStatusinEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecStatus",
                schema: "hrms",
                table: "Employee",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e70ceba-9a55-41f5-9a08-25679448db98", "AQAAAAEAACcQAAAAEGHlzOzJrrF+u0xxlJYmDFFcjiIKS4iWwI4f2GVeVb2rXo1GcD4u6BpK2/VbqkSnLQ==", "a1358c2f-e270-4c07-8188-57f00a6ab3cd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecStatus",
                schema: "hrms",
                table: "Employee");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b5816a3-008c-4902-bc9b-0a526d657867", "AQAAAAEAACcQAAAAEF/M9z9haHghyvKAI+1t7luOuvz+BA27UrUr39n0VGd40rAN+jSLVyMq/MabkVBs8g==", "b5278f18-ca86-4171-b7f1-414c9c41ec40" });
        }
    }
}
