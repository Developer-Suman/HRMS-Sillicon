using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class registerEmp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                schema: "Identity",
                table: "MyUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeNameEmployee_id",
                schema: "Identity",
                table: "MyUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb872c7d-8387-4010-be6b-dd7ab5f65c00", "AQAAAAEAACcQAAAAEPt1by2TFddnSBs2ngVLMuENt6eZsjS4f7bEbMfm+xCKfOu7HnWinFRCYe1zmJn8sw==", "035a8f4d-b68c-480f-9f9f-b5e5eccd1f97" });

            migrationBuilder.CreateIndex(
                name: "IX_MyUsers_EmployeeNameEmployee_id",
                schema: "Identity",
                table: "MyUsers",
                column: "EmployeeNameEmployee_id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyUsers_Employee_EmployeeNameEmployee_id",
                schema: "Identity",
                table: "MyUsers");

            migrationBuilder.DropIndex(
                name: "IX_MyUsers_EmployeeNameEmployee_id",
                schema: "Identity",
                table: "MyUsers");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                schema: "Identity",
                table: "MyUsers");

            migrationBuilder.DropColumn(
                name: "EmployeeNameEmployee_id",
                schema: "Identity",
                table: "MyUsers");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b0ce58f-c125-4d0c-816f-e8b8014e165e", "AQAAAAEAACcQAAAAEPPdIDS0xuZS3Ag07GqNkMUsH8vY7q9cWyoUYmZiKAOwJKk3SJONR00Ru/XQgT0F7A==", "19dccce5-a9a3-4057-854d-aace64f336d5" });
        }
    }
}
