using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class ss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b5816a3-008c-4902-bc9b-0a526d657867", "AQAAAAEAACcQAAAAEF/M9z9haHghyvKAI+1t7luOuvz+BA27UrUr39n0VGd40rAN+jSLVyMq/MabkVBs8g==", "b5278f18-ca86-4171-b7f1-414c9c41ec40" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d03ca832-d6db-4dfe-b0ce-0dbeba71e237", "AQAAAAEAACcQAAAAENdxsZsDwmpGGrGX9mO85mMkpu2RF4B9aGGlWwzMCsBdd0X5PUSOefp/b3Xun+bj3A==", "de0c25c9-d529-4c06-a34b-0b83579005e6" });
        }
    }
}
