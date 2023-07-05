using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Infrastructure.Migrations
{
    public partial class changeDbStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentCars_Reservations_ReservationId",
                table: "RentCars");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Hotels_HotelId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_RentCars_ReservationId",
                table: "RentCars");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "RentCars");

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "Reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "RentCarReservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    RentCarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentCarReservations", x => new { x.RentCarId, x.ReservationId });
                    table.ForeignKey(
                        name: "FK_RentCarReservations_RentCars_RentCarId",
                        column: x => x.RentCarId,
                        principalTable: "RentCars",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RentCarReservations_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoomReservations",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomReservations", x => new { x.RoomId, x.ReservationId });
                    table.ForeignKey(
                        name: "FK_RoomReservations_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoomReservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "RentCars",
                keyColumn: "Id",
                keyValue: 17,
                column: "CarImg",
                value: "/img/Cars/BmwX6 Black.jpeg");

            migrationBuilder.UpdateData(
                table: "RentCars",
                keyColumn: "Id",
                keyValue: 18,
                column: "CarImg",
                value: "/img/Cars/BmwX6 2021 Maroon.jpg");

            migrationBuilder.CreateIndex(
                name: "IX_RentCarReservations_ReservationId",
                table: "RentCarReservations",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomReservations_ReservationId",
                table: "RoomReservations",
                column: "ReservationId");

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

            migrationBuilder.DropTable(
                name: "RentCarReservations");

            migrationBuilder.DropTable(
                name: "RoomReservations");

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "RentCars",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "RentCars",
                keyColumn: "Id",
                keyValue: 17,
                column: "CarImg",
                value: "/img/Cars/BmwX6 Blue.jpeg");

            migrationBuilder.UpdateData(
                table: "RentCars",
                keyColumn: "Id",
                keyValue: 18,
                column: "CarImg",
                value: "/img/Cars/BmwX6 Blue.jpeg");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RentCars_ReservationId",
                table: "RentCars",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentCars_Reservations_ReservationId",
                table: "RentCars",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Hotels_HotelId",
                table: "Reservations",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Rooms_RoomId",
                table: "Reservations",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
