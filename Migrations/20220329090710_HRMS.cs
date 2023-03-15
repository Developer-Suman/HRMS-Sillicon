using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class HRMS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.EnsureSchema(
                name: "hrms");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "hrms",
                columns: table => new
                {
                    Department_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Department_id);
                });

            migrationBuilder.CreateTable(
                name: "Designation",
                schema: "hrms",
                columns: table => new
                {
                    Designation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.Designation_id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyUsers",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserRoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyUsers_AspNetRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalSchema: "Identity",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "hrms",
                columns: table => new
                {
                    Employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department_id = table.Column<int>(type: "int", nullable: true),
                    Designation_id = table.Column<int>(type: "int", nullable: true),
                    First_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marital_status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderEnum = table.Column<int>(type: "int", nullable: false),
                    Dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Joining_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Is_Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Employee_id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_Department_id",
                        column: x => x.Department_id,
                        principalSchema: "hrms",
                        principalTable: "Department",
                        principalColumn: "Department_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Designation_Designation_id",
                        column: x => x.Designation_id,
                        principalSchema: "hrms",
                        principalTable: "Designation",
                        principalColumn: "Designation_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_MyUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "MyUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_MyUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "MyUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_MyUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "MyUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_MyUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "MyUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendence",
                schema: "hrms",
                columns: table => new
                {
                    Attendence_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Current_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Turn_in = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Turn_out = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Employee_id = table.Column<int>(type: "int", nullable: false),
                    Is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendence", x => x.Attendence_id);
                    table.ForeignKey(
                        name: "FK_Attendence_Employee_Employee_id",
                        column: x => x.Employee_id,
                        principalSchema: "hrms",
                        principalTable: "Employee",
                        principalColumn: "Employee_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leave",
                schema: "hrms",
                columns: table => new
                {
                    Leave_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_id = table.Column<int>(type: "int", nullable: false),
                    Leave_reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_from = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_to = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total_days = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveTypeEnum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leave", x => x.Leave_id);
                    table.ForeignKey(
                        name: "FK_Leave_Employee_Employee_id",
                        column: x => x.Employee_id,
                        principalSchema: "hrms",
                        principalTable: "Employee",
                        principalColumn: "Employee_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resignation",
                schema: "hrms",
                columns: table => new
                {
                    Resignation_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resignation_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resign_reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Employee_id = table.Column<int>(type: "int", nullable: false),
                    Is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resignation", x => x.Resignation_id);
                    table.ForeignKey(
                        name: "FK_Resignation_Employee_Employee_id",
                        column: x => x.Employee_id,
                        principalSchema: "hrms",
                        principalTable: "Employee",
                        principalColumn: "Employee_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "1", "Admin", "Admin" },
                    { "2", "2", "Manager", "Manager" },
                    { "3", "3", "Employee", "Employee" },
                    { "4", "4", "HRManager", "HRManager" }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "MyUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Fullname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserRoleId" },
                values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, "389c1cec-8866-4d81-9c8f-d2ec06665e3e", "admin@gmail.com", false, null, false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEIsE0+GxTZqln5+4dZIRkPqGAdI9PwDBB5BM+Z9JhbwMpv/9yzjBDd1ILCBLTXVKqg==", "1234567890", false, "eec1ea99-d726-4f3b-8c32-b3c4a4b8f21a", false, "Admin", null });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "Identity",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "Identity",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "Identity",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "Identity",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendence_Employee_id",
                schema: "hrms",
                table: "Attendence",
                column: "Employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Department_id",
                schema: "hrms",
                table: "Employee",
                column: "Department_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Designation_id",
                schema: "hrms",
                table: "Employee",
                column: "Designation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_Employee_id",
                schema: "hrms",
                table: "Leave",
                column: "Employee_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "MyUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_MyUsers_UserRoleId",
                schema: "Identity",
                table: "MyUsers",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "MyUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Resignation_Employee_id",
                schema: "hrms",
                table: "Resignation",
                column: "Employee_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Attendence",
                schema: "hrms");

            migrationBuilder.DropTable(
                name: "Leave",
                schema: "hrms");

            migrationBuilder.DropTable(
                name: "Resignation",
                schema: "hrms");

            migrationBuilder.DropTable(
                name: "MyUsers",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "hrms");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "hrms");

            migrationBuilder.DropTable(
                name: "Designation",
                schema: "hrms");
        }
    }
}
