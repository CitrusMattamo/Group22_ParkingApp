using Microsoft.EntityFrameworkCore.Migrations;

namespace Group22_ParkingApp.Migrations
{
    public partial class memberId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MemberId",
                table: "Members",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Members");
        }
    }
}
