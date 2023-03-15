using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class NewNoticetableandSchemachangeforHoliday : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Holidays",
                table: "Holidays");

            migrationBuilder.RenameTable(
                name: "Holidays",
                newName: "Holiday",
                newSchema: "hrms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Holiday",
                schema: "hrms",
                table: "Holiday",
                column: "Holiday_Id");

            migrationBuilder.CreateTable(
                name: "Notice",
                schema: "hrms",
                columns: table => new
                {
                    NoticeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoticeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notice", x => x.NoticeId);
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d836d357-9197-4fd4-ac36-256fc10fdcb6", "AQAAAAEAACcQAAAAEN7Sla6iMjd7yuaMVDUz9a8RCUqBdF1bW9Wceto4PInewDL4bkGpJB3x/tnvrsfKoA==", "e74f9f06-4d9a-4e4b-9f18-f07afe55df4a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notice",
                schema: "hrms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Holiday",
                schema: "hrms",
                table: "Holiday");

            migrationBuilder.RenameTable(
                name: "Holiday",
                schema: "hrms",
                newName: "Holidays");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Holidays",
                table: "Holidays",
                column: "Holiday_Id");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1fc4d10-182e-48d2-8a9e-e901e7837efb", "AQAAAAEAACcQAAAAEBwNPBrpBr4a5P/IiK6ISxr1P2R/ayu152R84Y3BnzHmCWlQEbuE2mc3/Duhlx+8Eg==", "67842c29-7d0f-43ad-93d3-6c9692a8c8c2" });
        }
    }
}
