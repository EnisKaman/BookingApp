using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Infrastructure.Migrations
{
    public partial class addColumnToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomReservations_Reservations_ReservationId",
                table: "RoomReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomReservations_Rooms_RoomId",
                table: "RoomReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomReservations",
                table: "RoomReservations");

            migrationBuilder.RenameTable(
                name: "RoomReservations",
                newName: "RoomsReservations");

            migrationBuilder.RenameIndex(
                name: "IX_RoomReservations_ReservationId",
                table: "RoomsReservations",
                newName: "IX_RoomsReservations_ReservationId");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Reservations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomsReservations",
                table: "RoomsReservations",
                columns: new[] { "RoomId", "ReservationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsReservations_Reservations_ReservationId",
                table: "RoomsReservations",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomsReservations_Rooms_RoomId",
                table: "RoomsReservations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomsReservations_Reservations_ReservationId",
                table: "RoomsReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomsReservations_Rooms_RoomId",
                table: "RoomsReservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomsReservations",
                table: "RoomsReservations");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "RoomsReservations",
                newName: "RoomReservations");

            migrationBuilder.RenameIndex(
                name: "IX_RoomsReservations_ReservationId",
                table: "RoomReservations",
                newName: "IX_RoomReservations_ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomReservations",
                table: "RoomReservations",
                columns: new[] { "RoomId", "ReservationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_RoomReservations_Reservations_ReservationId",
                table: "RoomReservations",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomReservations_Rooms_RoomId",
                table: "RoomReservations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
