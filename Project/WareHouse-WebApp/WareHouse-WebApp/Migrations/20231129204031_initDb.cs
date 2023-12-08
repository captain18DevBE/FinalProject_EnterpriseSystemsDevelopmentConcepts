using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WareHouse_WebApp.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_DeliveryNotes_DeliveryNoteId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DeliveryNoteId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeliveryNoteId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryNoteId",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_DeliveryNoteId",
                table: "Products",
                column: "DeliveryNoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_DeliveryNotes_DeliveryNoteId",
                table: "Products",
                column: "DeliveryNoteId",
                principalTable: "DeliveryNotes",
                principalColumn: "DeliveryNoteId");
        }
    }
}
