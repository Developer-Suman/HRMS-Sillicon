using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class aa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a101e00-4cbd-4540-85b0-1a081cccbcc2", "AQAAAAEAACcQAAAAENlbCa8pIjPBsMoJWQbxMUQzaolV/hpRszPG8ATyb3Ta8uW9NPEU/pF5UQxsu13dLw==", "e29eb2a4-07b8-4b06-bf49-792c9a38ca14" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bf5607d-b00f-4fae-a13d-90b7856eae2c", "AQAAAAEAACcQAAAAENNs7FUcZiJTNMzvsOMFnpj85/y6m9ZL3eRp0QeK2dW/virow15YeF8Y5fXqbgWVXg==", "692dc379-c531-45e5-98ba-fa7217fdc609" });
        }
    }
}
