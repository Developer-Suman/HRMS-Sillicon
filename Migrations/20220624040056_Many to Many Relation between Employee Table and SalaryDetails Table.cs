using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class ManytoManyRelationbetweenEmployeeTableandSalaryDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalaryDetail",
                schema: "hrms",
                columns: table => new
                {
                    SalaryDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeSalary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaryImplementingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalaryStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryDetail", x => x.SalaryDetailId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSalaryDetail",
                schema: "hrms",
                columns: table => new
                {
                    Employee_id = table.Column<int>(type: "int", nullable: false),
                    SalaryDetailId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalaryDetail", x => new { x.Employee_id, x.SalaryDetailId });
                    table.ForeignKey(
                        name: "FK_EmployeeSalaryDetail_Employee_Employee_id",
                        column: x => x.Employee_id,
                        principalSchema: "hrms",
                        principalTable: "Employee",
                        principalColumn: "Employee_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSalaryDetail_SalaryDetail_SalaryDetailId",
                        column: x => x.SalaryDetailId,
                        principalSchema: "hrms",
                        principalTable: "SalaryDetail",
                        principalColumn: "SalaryDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a751624-565c-4ab8-a40b-1963b1726764", "AQAAAAEAACcQAAAAEErcyqDIEPWA5j7jnOHOVGxrKo5FoTLLWXEvKDjkBGam0FoJwUj+Cz/OCL1VA+3YzQ==", "f01024d2-1b32-4d69-88ee-8f96269e02ec" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalaryDetail_SalaryDetailId",
                schema: "hrms",
                table: "EmployeeSalaryDetail",
                column: "SalaryDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSalaryDetail",
                schema: "hrms");

            migrationBuilder.DropTable(
                name: "SalaryDetail",
                schema: "hrms");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46fb77c0-3a10-4ed8-a0bb-f98f827484ed", "AQAAAAEAACcQAAAAELLh1a9u7tT9vFb+agj2/CzFn4ttAqcrEAWmY3Wq2F8ravMOHeZW7MEgvHEQAUHu4w==", "963bdd8d-09fc-4b1e-8e04-eaa301cb25a4" });
        }
    }
}
