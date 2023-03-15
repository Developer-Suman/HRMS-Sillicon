using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class AddRecStatusinDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecStatus",
                schema: "hrms",
                table: "Department",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebd21a0e-da2c-4c0b-9065-f51d2858ae3b", "AQAAAAEAACcQAAAAEJ9/5Q7aGkoPMm32cBpfvYTSknqxH5QFAWeU//C0qw4r/FKNiyztL2ALMiZFrN7aTQ==", "6854b33e-5edb-4d47-86ef-1aa06f762ab3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecStatus",
                schema: "hrms",
                table: "Department");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e70ceba-9a55-41f5-9a08-25679448db98", "AQAAAAEAACcQAAAAEGHlzOzJrrF+u0xxlJYmDFFcjiIKS4iWwI4f2GVeVb2rXo1GcD4u6BpK2/VbqkSnLQ==", "a1358c2f-e270-4c07-8188-57f00a6ab3cd" });
        }
    }
}
