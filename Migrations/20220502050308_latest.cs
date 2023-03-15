using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class latest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f350b63c-3e1f-4732-b1c4-9dbc8526c387", "AQAAAAEAACcQAAAAEGnrd6HBXnB9D9cVDKrI326aoW4GheaVa/1TCRk8b1jWtWCyF/1+9ujLXgLGm/6Rqw==", "9528d981-bd86-4bdb-bf3c-5296860b4e72" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8c510347-4d12-41f9-b8e6-4ed409ae2a88", "AQAAAAEAACcQAAAAEOz2gJD4TaVd6PoJmaPNdyYHi2S8e+jSd4y7IlNxlcCmqep+szjwEZh4B3ydirCUBg==", "5f5a4788-8910-4401-a04e-c1bfc9307420" });
        }
    }
}
