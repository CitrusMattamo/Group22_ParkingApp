using Microsoft.EntityFrameworkCore.Migrations;

namespace Group22_ParkingApp.Migrations
{
    public partial class userID_Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StaffId",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Members",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Members");
        }
    }
}
