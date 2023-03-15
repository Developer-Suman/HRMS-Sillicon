using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class requiredfieldremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5868eac-ff16-4fc8-a6e6-8f0bd2d39d9c", "AQAAAAEAACcQAAAAEGfzAqYVWJkWXwPskrB5gpIgUR1WCemf2SNxokgnSFVojRNpvuvbKWCCv5nHGAw6/w==", "c95d48a9-7c71-47a9-9fda-45d0673fa376" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8fe4b7a-a9e7-4516-a6dc-c5877b74f0b7", "AQAAAAEAACcQAAAAEHTjSzsSSnLojImeUSImv3nwV6J8VAYMVdmzn07Du0u7adJhhESoapTYvMM9fqaqpw==", "723edc52-cd94-4e1f-bca2-55fe7503f392" });
        }
    }
}
