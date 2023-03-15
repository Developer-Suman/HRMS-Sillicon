using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class LeaveApproval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AppliedOnDate",
                schema: "hrms",
                table: "Leave",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "LeaveApproval",
                schema: "hrms",
                table: "Leave",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a25e1e5-7446-4ac3-b3a8-928b2f403d8e", "AQAAAAEAACcQAAAAEOmtLgOHhtZlLEQfx+eowlAzeOKWIhnQwYwSj6KesYXFqPN28yEPxY2vOI+RYNpybA==", "5b94ddf4-5aa4-435e-8374-151827bc7bcf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppliedOnDate",
                schema: "hrms",
                table: "Leave");

            migrationBuilder.DropColumn(
                name: "LeaveApproval",
                schema: "hrms",
                table: "Leave");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb872c7d-8387-4010-be6b-dd7ab5f65c00", "AQAAAAEAACcQAAAAEPt1by2TFddnSBs2ngVLMuENt6eZsjS4f7bEbMfm+xCKfOu7HnWinFRCYe1zmJn8sw==", "035a8f4d-b68c-480f-9f9f-b5e5eccd1f97" });
        }
    }
}
