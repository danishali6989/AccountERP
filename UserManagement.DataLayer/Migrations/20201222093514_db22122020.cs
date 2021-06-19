using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class db22122020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartingBalance",
                table: "Reconciliations",
                newName: "StatementBalance");

            migrationBuilder.RenameColumn(
                name: "EndingBalance",
                table: "Reconciliations",
                newName: "IcloseBalance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatementBalance",
                table: "Reconciliations",
                newName: "StartingBalance");

            migrationBuilder.RenameColumn(
                name: "IcloseBalance",
                table: "Reconciliations",
                newName: "EndingBalance");
        }
    }
}
