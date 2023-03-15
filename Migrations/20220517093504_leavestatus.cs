using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class leavestatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LeaveApproval",
                schema: "hrms",
                table: "Leave",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bf5607d-b00f-4fae-a13d-90b7856eae2c", "AQAAAAEAACcQAAAAENNs7FUcZiJTNMzvsOMFnpj85/y6m9ZL3eRp0QeK2dW/virow15YeF8Y5fXqbgWVXg==", "692dc379-c531-45e5-98ba-fa7217fdc609" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "LeaveApproval",
                schema: "hrms",
                table: "Leave",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5868eac-ff16-4fc8-a6e6-8f0bd2d39d9c", "AQAAAAEAACcQAAAAEGfzAqYVWJkWXwPskrB5gpIgUR1WCemf2SNxokgnSFVojRNpvuvbKWCCv5nHGAw6/w==", "c95d48a9-7c71-47a9-9fda-45d0673fa376" });
        }
    }
}
