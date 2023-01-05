using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_webconfigupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WebTitle",
                table: "webConfigs",
                newName: "OptionValue");

            migrationBuilder.RenameColumn(
                name: "SystemNot",
                table: "webConfigs",
                newName: "OptionName");

            migrationBuilder.RenameColumn(
                name: "WebConfigID",
                table: "webConfigs",
                newName: "OptionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OptionValue",
                table: "webConfigs",
                newName: "WebTitle");

            migrationBuilder.RenameColumn(
                name: "OptionName",
                table: "webConfigs",
                newName: "SystemNot");

            migrationBuilder.RenameColumn(
                name: "OptionID",
                table: "webConfigs",
                newName: "WebConfigID");
        }
    }
}
