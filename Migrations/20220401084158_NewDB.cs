using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class NewDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Marital_status",
                schema: "hrms",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b0ce58f-c125-4d0c-816f-e8b8014e165e", "AQAAAAEAACcQAAAAEPPdIDS0xuZS3Ag07GqNkMUsH8vY7q9cWyoUYmZiKAOwJKk3SJONR00Ru/XQgT0F7A==", "19dccce5-a9a3-4057-854d-aace64f336d5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Marital_status",
                schema: "hrms",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "389c1cec-8866-4d81-9c8f-d2ec06665e3e", "AQAAAAEAACcQAAAAEIsE0+GxTZqln5+4dZIRkPqGAdI9PwDBB5BM+Z9JhbwMpv/9yzjBDd1ILCBLTXVKqg==", "eec1ea99-d726-4f3b-8c32-b3c4a4b8f21a" });
        }
    }
}
