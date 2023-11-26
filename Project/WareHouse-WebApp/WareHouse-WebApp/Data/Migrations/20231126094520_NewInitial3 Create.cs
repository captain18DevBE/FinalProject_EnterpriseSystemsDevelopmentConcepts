using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHouse_WebApp.Data.Migrations
{
    public partial class NewInitial3Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "DeliveryNotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "DeliveryNotes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "DeliveryNotes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "DeliveryNotes");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "DeliveryNotes");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "DeliveryNotes");
        }
    }
}
