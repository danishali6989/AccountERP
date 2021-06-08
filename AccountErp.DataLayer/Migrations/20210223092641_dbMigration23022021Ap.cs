using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class dbMigration23022021Ap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tenent_Id",
                table: "WareHouse",
                newName: "CompanyTenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyTenantId",
                table: "WareHouse",
                newName: "Tenent_Id");
        }
    }
}
