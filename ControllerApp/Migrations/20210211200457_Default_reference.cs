using Microsoft.EntityFrameworkCore.Migrations;

namespace ControllerApp.Migrations
{
    public partial class Default_reference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReferenceNo",
                table: "CarBookings",
                nullable: true,
                defaultValue: "CB",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ReferenceNo",
                table: "CarBookings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValue: "CB");
        }
    }
}
