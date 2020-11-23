using Microsoft.EntityFrameworkCore.Migrations;

namespace Group22_ParkingApp.Migrations
{
    public partial class spotsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParkingSpotId",
                table: "ParkingLots",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ParkingSpots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isAvailible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpots", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingLots_ParkingSpotId",
                table: "ParkingLots",
                column: "ParkingSpotId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingLots_ParkingSpots_ParkingSpotId",
                table: "ParkingLots",
                column: "ParkingSpotId",
                principalTable: "ParkingSpots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingLots_ParkingSpots_ParkingSpotId",
                table: "ParkingLots");

            migrationBuilder.DropTable(
                name: "ParkingSpots");

            migrationBuilder.DropIndex(
                name: "IX_ParkingLots_ParkingSpotId",
                table: "ParkingLots");

            migrationBuilder.DropColumn(
                name: "ParkingSpotId",
                table: "ParkingLots");
        }
    }
}
