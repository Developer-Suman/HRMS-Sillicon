using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48481402-292a-4fe0-b8c2-18a706a78c28", "AQAAAAEAACcQAAAAEL//GThd8m56gOxCZXRDa6Pb9QYDa35p9k6J4NXuSuNzwEBdHF2P46wWAX1hynOAkA==", "e47b7399-6305-44e9-8b6c-6b20f92f7a17" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a751624-565c-4ab8-a40b-1963b1726764", "AQAAAAEAACcQAAAAEErcyqDIEPWA5j7jnOHOVGxrKo5FoTLLWXEvKDjkBGam0FoJwUj+Cz/OCL1VA+3YzQ==", "f01024d2-1b32-4d69-88ee-8f96269e02ec" });
        }
    }
}
