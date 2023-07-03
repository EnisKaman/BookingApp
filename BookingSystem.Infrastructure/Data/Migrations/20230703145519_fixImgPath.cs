using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingSystem.Infrastructure.Migrations
{
    public partial class fixImgPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RentCars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CarImg",
                value: "/img/Cars/Bmw X1 2015.jpg");

            migrationBuilder.UpdateData(
                table: "RentCars",
                keyColumn: "Id",
                keyValue: 10,
                column: "CarImg",
                value: "/img/Cars/Mercedes GLE 2016.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RentCars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CarImg",
                value: "/img/Cars/Bmw X3 2018.jpg");

            migrationBuilder.UpdateData(
                table: "RentCars",
                keyColumn: "Id",
                keyValue: 10,
                column: "CarImg",
                value: "/img/Cars/Mercedes C63 2012.jpg");
        }
    }
}
