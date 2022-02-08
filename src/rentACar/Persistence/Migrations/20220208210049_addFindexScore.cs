using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class addFindexScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IndividualCustomers_CustomerId",
                table: "IndividualCustomers");

            migrationBuilder.DropIndex(
                name: "IX_CorporateCustomers_CustomerId",
                table: "CorporateCustomers");

            migrationBuilder.AddColumn<int>(
                name: "FindexScore",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "FindexScore",
                value: 1750);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "FindexScore",
                value: 1520);

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomers_CustomerId",
                table: "IndividualCustomers",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomers_CustomerId",
                table: "CorporateCustomers",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_IndividualCustomers_CustomerId",
                table: "IndividualCustomers");

            migrationBuilder.DropIndex(
                name: "IX_CorporateCustomers_CustomerId",
                table: "CorporateCustomers");

            migrationBuilder.DropColumn(
                name: "FindexScore",
                table: "Cars");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualCustomers_CustomerId",
                table: "IndividualCustomers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCustomers_CustomerId",
                table: "CorporateCustomers",
                column: "CustomerId");
        }
    }
}
