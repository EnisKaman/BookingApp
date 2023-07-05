using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Infrastructure.Migrations
{
    public partial class addRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_HotelId",
                table: "Reservations",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Hotels_HotelId",
                table: "Reservations",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Hotels_HotelId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_HotelId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Reservations");
        }
    }
}
