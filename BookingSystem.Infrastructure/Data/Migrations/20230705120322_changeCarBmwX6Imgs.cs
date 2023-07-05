using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Infrastructure.Migrations
{
    public partial class changeCarBmwX6Imgs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RentCars",
                keyColumn: "Id",
                keyValue: 17,
                column: "CarImg",
                value: "/img/Cars/BmwX6 Black.jpg");

            migrationBuilder.UpdateData(
                table: "RentCars",
                keyColumn: "Id",
                keyValue: 18,
                column: "CarImg",
                value: "/img/Cars/Bmw X6 2021 Maroon.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
