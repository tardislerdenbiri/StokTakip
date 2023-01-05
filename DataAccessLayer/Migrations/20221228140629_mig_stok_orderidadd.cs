using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_stok_orderidadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "Stoks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stoks_OrderID",
                table: "Stoks",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Stoks_Orders_OrderID",
                table: "Stoks",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stoks_Orders_OrderID",
                table: "Stoks");

            migrationBuilder.DropIndex(
                name: "IX_Stoks_OrderID",
                table: "Stoks");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Stoks");
        }
    }
}
