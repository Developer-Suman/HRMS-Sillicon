using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class AddSoftDeleteonDesignation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecStatus",
                schema: "hrms",
                table: "Designation",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b63a1e5f-4ad3-422a-9333-76a20984f46d", "AQAAAAEAACcQAAAAEKNf/ucOPJ4+Bzf9n6XZk36Xy6EZ8/7FhGcFLy6WTWWDvsvDEbQXN5boR7t0k1HXaA==", "6685f41c-638b-4252-aba0-4fd69e06111f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecStatus",
                schema: "hrms",
                table: "Designation");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebd21a0e-da2c-4c0b-9065-f51d2858ae3b", "AQAAAAEAACcQAAAAEJ9/5Q7aGkoPMm32cBpfvYTSknqxH5QFAWeU//C0qw4r/FKNiyztL2ALMiZFrN7aTQ==", "6854b33e-5edb-4d47-86ef-1aa06f762ab3" });
        }
    }
}
