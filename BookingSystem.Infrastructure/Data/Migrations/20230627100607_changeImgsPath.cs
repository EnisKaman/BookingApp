using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Infrastructure.Migrations
{
    public partial class changeImgsPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 25,
                column: "Path",
                value: "/img/Rooms/Spa hotel Infinity rooms/Spa Hotel Infinity house2.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 44,
                column: "Path",
                value: "/img/Rooms/Porta Nuova rooms/Porta Nuova apartment2.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 49,
                column: "Path",
                value: "/img/Rooms/Paradise rooms/Paradise doublebed1.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 50,
                column: "Path",
                value: "/img/Rooms/Paradise rooms/Paradise double bed2.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 52,
                column: "Path",
                value: "/img/Rooms/Paradise rooms/Paradise studio2.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 53,
                column: "Path",
                value: "/img/Rooms/Paradise rooms/Paradise studio3.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 54,
                column: "Path",
                value: "/img/Rooms/Paradise rooms/Paradise stuido 4.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 57,
                column: "Path",
                value: "/img/Hotels/Hotel Amelia/Hotel Amelia1.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 58,
                column: "Path",
                value: "/img/Hotels/Hotel Amelia/Hotel Amelia2.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 59,
                column: "Path",
                value: "/img/Hotels/Hotel Amelia/Hotel Amelia3.jpg");

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "HotelId", "Path", "RoomId" },
                values: new object[] { 69, 4, "/img/Hotels/NH Collection Milano Porta Nuova/Porta Nuova2.jpg", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 25,
                column: "Path",
                value: "/img/Rooms/Spa hotel Infinity rooms/Spa hotel Infinity rooms/Spa Hotel Infinity house2.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 44,
                column: "Path",
                value: "/img/Rooms/Porta Nuova rooms/Porta Nuova aapartment2.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 49,
                column: "Path",
                value: "/img/Rooms//Paradise rooms/Paradise doublebed1.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 50,
                column: "Path",
                value: "/img/Rooms//Paradise rooms/Paradise doublebed2.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 52,
                column: "Path",
                value: "/img/Rooms/Paradise rooms/Paradise stuido2.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 53,
                column: "Path",
                value: "/img/Rooms/Paradise rooms/Paradise stuido3.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 54,
                column: "Path",
                value: "/img/Rooms/Paradise rooms/Paradise stuido4.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 57,
                column: "Path",
                value: "/Hotels/Hotel Amelia/Hotel Amelia1.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 58,
                column: "Path",
                value: "/Hotels/Hotel Amelia/Hotel Amelia2.jpg");

            migrationBuilder.UpdateData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: 59,
                column: "Path",
                value: "/Hotels/Hotel Amelia/Hotel Amelia3.jpg");
        }
    }
}
