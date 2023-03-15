using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class empfullname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e97887de-0e26-4b90-92d5-3c1e4f9ba398", "AQAAAAEAACcQAAAAEIxCsd2xr8w2SsDzGIUiC+dkYl6zK2SzDMsbNi067w/gdYZCqKlNIyoxQlUFkcG1ow==", "d2d905a0-482f-4351-8c70-77721c83cbb7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d449e204-36cc-4bef-af2b-a0f268300ae3", "AQAAAAEAACcQAAAAEJ6WhQdZa8Q9C7RKPloxNrDmj5rcMLBhOXfa1nsO+AbVeL3/3uWBLw8MLdkG6EJEog==", "9194d5a6-3518-4bb4-b427-a2c50d68e267" });
        }
    }
}
