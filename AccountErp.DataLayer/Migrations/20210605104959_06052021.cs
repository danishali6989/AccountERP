using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class _06052021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "App_id",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Finance_year",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Ip_Address",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyTenantId",
                table: "Invoices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyTenantId",
                table: "InvoicePayments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyTenantId",
                table: "CreditMemo",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "App_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Finance_year",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Ip_Address",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyTenantId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CompanyTenantId",
                table: "InvoicePayments");

            migrationBuilder.DropColumn(
                name: "CompanyTenantId",
                table: "CreditMemo");
        }
    }
}
