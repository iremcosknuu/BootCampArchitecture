using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class rental4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CarId", "RentDate", "RentKilometer", "ReturnDate", "ReturnKilometer" },
                values: new object[] { 1, 1, new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), 13000.0, new DateTime(2022, 2, 6, 0, 0, 0, 0, DateTimeKind.Local), 13500.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
