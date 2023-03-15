using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class datetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c510347-4d12-41f9-b8e6-4ed409ae2a88", "AQAAAAEAACcQAAAAEOz2gJD4TaVd6PoJmaPNdyYHi2S8e+jSd4y7IlNxlcCmqep+szjwEZh4B3ydirCUBg==", "5f5a4788-8910-4401-a04e-c1bfc9307420" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e97887de-0e26-4b90-92d5-3c1e4f9ba398", "AQAAAAEAACcQAAAAEIxCsd2xr8w2SsDzGIUiC+dkYl6zK2SzDMsbNi067w/gdYZCqKlNIyoxQlUFkcG1ow==", "d2d905a0-482f-4351-8c70-77721c83cbb7" });
        }
    }
}
