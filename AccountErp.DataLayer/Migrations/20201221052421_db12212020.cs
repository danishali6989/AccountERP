using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class db12212020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReconciliationStatuse",
                table: "Reconciliations",
                newName: "ReconciliationStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReconciliationStatus",
                table: "Reconciliations",
                newName: "ReconciliationStatuse");
        }
    }
}
