using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHouse_WebApp.Data.Migrations
{
    public partial class Initial2Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ManufacturerId",
                table: "GoodsReceipts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "GoodsReceipts");
        }
    }
}
