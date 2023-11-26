using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHouse_WebApp.Data.Migrations
{
    public partial class NewInitial4Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountProduct",
                table: "DeliveryNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountProduct",
                table: "DeliveryNotes");
        }
    }
}
