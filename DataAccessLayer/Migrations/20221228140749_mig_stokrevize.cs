using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_stokrevize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stoks_Companies_CompanyID",
                table: "Stoks");

            migrationBuilder.DropIndex(
                name: "IX_Stoks_CompanyID",
                table: "Stoks");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Stoks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "Stoks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stoks_CompanyID",
                table: "Stoks",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Stoks_Companies_CompanyID",
                table: "Stoks",
                column: "CompanyID",
                principalTable: "Companies",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
