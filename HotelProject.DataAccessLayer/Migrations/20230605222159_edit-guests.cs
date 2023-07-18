using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class editguests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Guests",
                newName: "Room");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Guests",
                newName: "Mail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Room",
                table: "Guests",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "Guests",
                newName: "City");
        }
    }
}
