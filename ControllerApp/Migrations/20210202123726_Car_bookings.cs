using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControllerApp.Migrations
{
    public partial class Car_bookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegistrationNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "CarBookings",
                columns: table => new
                {
                    CarBookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingReason = table.Column<string>(nullable: false),
                    ReferenceNo = table.Column<string>(nullable: false),
                    BookingFrom = table.Column<DateTime>(nullable: false),
                    BookingTo = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    DateCaptured = table.Column<DateTime>(nullable: false),
                    UserCatured = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBookings", x => x.CarBookingId);
                    table.ForeignKey(
                        name: "FK_CarBookings_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarBookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarBookings_CarId",
                table: "CarBookings",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarBookings_UserId",
                table: "CarBookings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarBookings");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
