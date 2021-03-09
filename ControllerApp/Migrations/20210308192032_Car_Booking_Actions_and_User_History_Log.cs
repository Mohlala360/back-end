using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControllerApp.Migrations
{
    public partial class Car_Booking_Actions_and_User_History_Log : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarBookStatuses",
                columns: table => new
                {
                    CarBookStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBookStatuses", x => x.CarBookStatusId);
                });

            migrationBuilder.CreateTable(
                name: "CarBookStates",
                columns: table => new
                {
                    CarBookStatusId = table.Column<int>(nullable: false),
                    CarBookingId = table.Column<int>(nullable: false),
                    CarBookStateId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBookStates", x => new { x.CarBookingId, x.CarBookStatusId });
                    table.ForeignKey(
                        name: "FK_CarBookStates_CarBookings_CarBookStateId",
                        column: x => x.CarBookStateId,
                        principalTable: "CarBookings",
                        principalColumn: "CarBookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarBookStates_CarBookStatuses_CarBookStatusId",
                        column: x => x.CarBookStatusId,
                        principalTable: "CarBookStatuses",
                        principalColumn: "CarBookStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CarBookStatuses",
                columns: new[] { "CarBookStatusId", "Status" },
                values: new object[] { 1, "New" });

            migrationBuilder.InsertData(
                table: "CarBookStatuses",
                columns: new[] { "CarBookStatusId", "Status" },
                values: new object[] { 2, "Out" });

            migrationBuilder.InsertData(
                table: "CarBookStatuses",
                columns: new[] { "CarBookStatusId", "Status" },
                values: new object[] { 3, "Back" });

            migrationBuilder.CreateIndex(
                name: "IX_CarBookStates_CarBookStateId",
                table: "CarBookStates",
                column: "CarBookStateId");

            migrationBuilder.CreateIndex(
                name: "IX_CarBookStates_CarBookStatusId",
                table: "CarBookStates",
                column: "CarBookStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarBookStates");

            migrationBuilder.DropTable(
                name: "CarBookStatuses");
        }
    }
}
