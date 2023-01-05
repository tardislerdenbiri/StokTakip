using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "Stoks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductsID",
                table: "Stoks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoresID",
                table: "Stoks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "Histories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "Histories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stoks_CompanyID",
                table: "Stoks",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Stoks_ProductsID",
                table: "Stoks",
                column: "ProductsID");

            migrationBuilder.CreateIndex(
                name: "IX_Stoks_StoresID",
                table: "Stoks",
                column: "StoresID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CompanyID",
                table: "Orders",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_CompanyID",
                table: "Histories",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Histories_OrderID",
                table: "Histories",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Companies_CompanyID",
                table: "Histories",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_Orders_OrderID",
                table: "Histories",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Companies_CompanyID",
                table: "Orders",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "CompanyID",
                onDelete: (ReferentialAction)DeleteBehavior.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stoks_Companies_CompanyID",
                table: "Stoks",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stoks_Products_ProductsID",
                table: "Stoks",
                column: "ProductsID",
                principalTable: "Products",
                principalColumn: "ProductsID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stoks_Stores_StoresID",
                table: "Stoks",
                column: "StoresID",
                principalTable: "Stores",
                principalColumn: "StoresID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Companies_CompanyID",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Histories_Orders_OrderID",
                table: "Histories");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Companies_CompanyID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Stoks_Companies_CompanyID",
                table: "Stoks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stoks_Products_ProductsID",
                table: "Stoks");

            migrationBuilder.DropForeignKey(
                name: "FK_Stoks_Stores_StoresID",
                table: "Stoks");

            migrationBuilder.DropIndex(
                name: "IX_Stoks_CompanyID",
                table: "Stoks");

            migrationBuilder.DropIndex(
                name: "IX_Stoks_ProductsID",
                table: "Stoks");

            migrationBuilder.DropIndex(
                name: "IX_Stoks_StoresID",
                table: "Stoks");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CompanyID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Histories_CompanyID",
                table: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Histories_OrderID",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Stoks");

            migrationBuilder.DropColumn(
                name: "ProductsID",
                table: "Stoks");

            migrationBuilder.DropColumn(
                name: "StoresID",
                table: "Stoks");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Histories");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "Histories");
        }
    }
}
