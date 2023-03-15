using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class NewHolidaytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Holiday_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HolidayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Holiday_Id);
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1fc4d10-182e-48d2-8a9e-e901e7837efb", "AQAAAAEAACcQAAAAEBwNPBrpBr4a5P/IiK6ISxr1P2R/ayu152R84Y3BnzHmCWlQEbuE2mc3/Duhlx+8Eg==", "67842c29-7d0f-43ad-93d3-6c9692a8c8c2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45b22171-560b-4d51-8a79-1da6973cd606", "AQAAAAEAACcQAAAAEFk7o7ZFyELlvXbtkjHfbwhCAbIxPhQgWX0fdKr11GegBUC688xA2s0B1beA1VAJJg==", "042035ec-6cf5-485f-b951-c1a6289be1df" });
        }
    }
}
