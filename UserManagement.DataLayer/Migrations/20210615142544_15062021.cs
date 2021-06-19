using Microsoft.EntityFrameworkCore.Migrations;

namespace UserManagement.DataLayer.Migrations
{
    public partial class _15062021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companys_CompanyTenantId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "CompanyTenantId",
                table: "Users",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CompanyTenantId",
                table: "Users",
                newName: "IX_Users_CompanyId");

            migrationBuilder.RenameColumn(
                name: "CompanyTenantId",
                table: "LoginModule",
                newName: "CompanyId");

            migrationBuilder.RenameColumn(
                name: "CompanyTenantId",
                table: "Companys",
                newName: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companys_CompanyId",
                table: "Users",
                column: "CompanyId",
                principalTable: "Companys",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companys_CompanyId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Users",
                newName: "CompanyTenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_CompanyId",
                table: "Users",
                newName: "IX_Users_CompanyTenantId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "LoginModule",
                newName: "CompanyTenantId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Companys",
                newName: "CompanyTenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companys_CompanyTenantId",
                table: "Users",
                column: "CompanyTenantId",
                principalTable: "Companys",
                principalColumn: "CompanyTenantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
