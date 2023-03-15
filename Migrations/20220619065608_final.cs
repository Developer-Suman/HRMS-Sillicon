using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyUsers_Employee_EmployeeNameEmployee_id",
                schema: "Identity",
                table: "MyUsers");

            migrationBuilder.RenameColumn(
                name: "EmployeeNameEmployee_id",
                schema: "Identity",
                table: "MyUsers",
                newName: "Employee_id");

            migrationBuilder.RenameIndex(
                name: "IX_MyUsers_EmployeeNameEmployee_id",
                schema: "Identity",
                table: "MyUsers",
                newName: "IX_MyUsers_Employee_id");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                schema: "Identity",
                table: "MyUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46fb77c0-3a10-4ed8-a0bb-f98f827484ed", "AQAAAAEAACcQAAAAELLh1a9u7tT9vFb+agj2/CzFn4ttAqcrEAWmY3Wq2F8ravMOHeZW7MEgvHEQAUHu4w==", "963bdd8d-09fc-4b1e-8e04-eaa301cb25a4" });

            migrationBuilder.AddForeignKey(
                name: "FK_MyUsers_Employee_Employee_id",
                schema: "Identity",
                table: "MyUsers",
                column: "Employee_id",
                principalSchema: "hrms",
                principalTable: "Employee",
                principalColumn: "Employee_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyUsers_Employee_Employee_id",
                schema: "Identity",
                table: "MyUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                schema: "Identity",
                table: "MyUsers");

            migrationBuilder.RenameColumn(
                name: "Employee_id",
                schema: "Identity",
                table: "MyUsers",
                newName: "EmployeeNameEmployee_id");

            migrationBuilder.RenameIndex(
                name: "IX_MyUsers_Employee_id",
                schema: "Identity",
                table: "MyUsers",
                newName: "IX_MyUsers_EmployeeNameEmployee_id");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d836d357-9197-4fd4-ac36-256fc10fdcb6", "AQAAAAEAACcQAAAAEN7Sla6iMjd7yuaMVDUz9a8RCUqBdF1bW9Wceto4PInewDL4bkGpJB3x/tnvrsfKoA==", "e74f9f06-4d9a-4e4b-9f18-f07afe55df4a" });

            migrationBuilder.AddForeignKey(
                name: "FK_MyUsers_Employee_EmployeeNameEmployee_id",
                schema: "Identity",
                table: "MyUsers",
                column: "EmployeeNameEmployee_id",
                principalSchema: "hrms",
                principalTable: "Employee",
                principalColumn: "Employee_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
