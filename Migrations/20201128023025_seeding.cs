using Microsoft.EntityFrameworkCore.Migrations;

namespace Group22_ParkingApp.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    LicenseNo = table.Column<string>(maxLength: 8, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NonMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LicenseNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingLots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    TotalSpaces = table.Column<int>(nullable: false),
                    AvailableSpaces = table.Column<int>(nullable: false),
                    MembershipFee = table.Column<int>(nullable: false),
                    ReservationFee = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingLots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpots",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isAvailable = table.Column<bool>(nullable: false),
                    ParkingLotId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingSpots_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingSpots_ParkingLots_ParkingLotId",
                        column: x => x.ParkingLotId,
                        principalTable: "ParkingLots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingLotId = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    NonMemberId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_NonMembers_NonMemberId",
                        column: x => x.NonMemberId,
                        principalTable: "NonMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_ParkingLots_ParkingLotId",
                        column: x => x.ParkingLotId,
                        principalTable: "ParkingLots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_MemberId",
                table: "ParkingSpots",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_ParkingLotId",
                table: "ParkingSpots",
                column: "ParkingLotId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_MemberId",
                table: "Reservations",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_NonMemberId",
                table: "Reservations",
                column: "NonMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ParkingLotId",
                table: "Reservations",
                column: "ParkingLotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingSpots");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "NonMembers");

            migrationBuilder.DropTable(
                name: "ParkingLots");
        }
    }
}
