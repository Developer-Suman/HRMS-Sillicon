using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class AddUserActivity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivityDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userActivities", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d03ca832-d6db-4dfe-b0ce-0dbeba71e237", "AQAAAAEAACcQAAAAENdxsZsDwmpGGrGX9mO85mMkpu2RF4B9aGGlWwzMCsBdd0X5PUSOefp/b3Xun+bj3A==", "de0c25c9-d529-4c06-a34b-0b83579005e6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userActivities");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48481402-292a-4fe0-b8c2-18a706a78c28", "AQAAAAEAACcQAAAAEL//GThd8m56gOxCZXRDa6Pb9QYDa35p9k6J4NXuSuNzwEBdHF2P46wWAX1hynOAkA==", "e47b7399-6305-44e9-8b6c-6b20f92f7a17" });
        }
    }
}
