using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControllerApp.Migrations
{
    public partial class Date_Added_for_car : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCaptured",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCaptured",
                table: "Cars");
        }
    }
}
