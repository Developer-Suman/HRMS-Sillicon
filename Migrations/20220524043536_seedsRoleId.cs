using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class seedsRoleId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserRoleId" },
                values: new object[] { "45b22171-560b-4d51-8a79-1da6973cd606", "AQAAAAEAACcQAAAAEFk7o7ZFyELlvXbtkjHfbwhCAbIxPhQgWX0fdKr11GegBUC688xA2s0B1beA1VAJJg==", "042035ec-6cf5-485f-b951-c1a6289be1df", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp", "UserRoleId" },
                values: new object[] { "8a101e00-4cbd-4540-85b0-1a081cccbcc2", "AQAAAAEAACcQAAAAENlbCa8pIjPBsMoJWQbxMUQzaolV/hpRszPG8ATyb3Ta8uW9NPEU/pF5UQxsu13dLw==", "e29eb2a4-07b8-4b06-bf49-792c9a38ca14", null });
        }
    }
}
