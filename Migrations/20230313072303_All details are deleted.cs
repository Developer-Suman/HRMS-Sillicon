using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class Alldetailsaredeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecStatus",
                schema: "hrms",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "RecStatus",
                schema: "hrms",
                table: "Designation");

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
                values: new object[] { "735da6b7-13ed-4d9c-9866-741bcb119383", "AQAAAAEAACcQAAAAELvq106WyI9Cj77NxAHmtiKkIDyENXqbyknzWTiEOkGTTeCiMjDYghhwMI+C5EqB6Q==", "872df28f-9e13-4f48-b502-7e89084a1446" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecStatus",
                schema: "hrms",
                table: "Employee",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecStatus",
                schema: "hrms",
                table: "Designation",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

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
                values: new object[] { "b63a1e5f-4ad3-422a-9333-76a20984f46d", "AQAAAAEAACcQAAAAEKNf/ucOPJ4+Bzf9n6XZk36Xy6EZ8/7FhGcFLy6WTWWDvsvDEbQXN5boR7t0k1HXaA==", "6685f41c-638b-4252-aba0-4fd69e06111f" });
        }
    }
}
