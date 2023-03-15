using Microsoft.EntityFrameworkCore.Migrations;

namespace HRMS_Silicon.Migrations
{
    public partial class attendence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Turn_out",
                schema: "hrms",
                table: "Attendence",
                newName: "Turn_Out");

            migrationBuilder.RenameColumn(
                name: "Turn_in",
                schema: "hrms",
                table: "Attendence",
                newName: "Turn_In");

            migrationBuilder.RenameColumn(
                name: "Is_active",
                schema: "hrms",
                table: "Attendence",
                newName: "Is_Active");

            migrationBuilder.RenameColumn(
                name: "Current_date",
                schema: "hrms",
                table: "Attendence",
                newName: "Current_Date");

            migrationBuilder.RenameColumn(
                name: "Attendence_id",
                schema: "hrms",
                table: "Attendence",
                newName: "Attendence_Id");

            migrationBuilder.AddColumn<string>(
                name: "TotalHours",
                schema: "hrms",
                table: "Attendence",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d449e204-36cc-4bef-af2b-a0f268300ae3", "AQAAAAEAACcQAAAAEJ6WhQdZa8Q9C7RKPloxNrDmj5rcMLBhOXfa1nsO+AbVeL3/3uWBLw8MLdkG6EJEog==", "9194d5a6-3518-4bb4-b427-a2c50d68e267" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalHours",
                schema: "hrms",
                table: "Attendence");

            migrationBuilder.RenameColumn(
                name: "Turn_Out",
                schema: "hrms",
                table: "Attendence",
                newName: "Turn_out");

            migrationBuilder.RenameColumn(
                name: "Turn_In",
                schema: "hrms",
                table: "Attendence",
                newName: "Turn_in");

            migrationBuilder.RenameColumn(
                name: "Is_Active",
                schema: "hrms",
                table: "Attendence",
                newName: "Is_active");

            migrationBuilder.RenameColumn(
                name: "Current_Date",
                schema: "hrms",
                table: "Attendence",
                newName: "Current_date");

            migrationBuilder.RenameColumn(
                name: "Attendence_Id",
                schema: "hrms",
                table: "Attendence",
                newName: "Attendence_id");

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "MyUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a25e1e5-7446-4ac3-b3a8-928b2f403d8e", "AQAAAAEAACcQAAAAEOmtLgOHhtZlLEQfx+eowlAzeOKWIhnQwYwSj6KesYXFqPN28yEPxY2vOI+RYNpybA==", "5b94ddf4-5aa4-435e-8374-151827bc7bcf" });
        }
    }
}
