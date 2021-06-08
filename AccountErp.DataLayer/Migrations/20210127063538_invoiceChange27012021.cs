using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class invoiceChange27012021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceServices_Items_ServiceId",
                table: "InvoiceServices");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "InvoiceServices",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "InvoiceServices",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceType",
                table: "Invoices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceServices_ProductId",
                table: "InvoiceServices",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceServices_Products_ProductId",
                table: "InvoiceServices",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceServices_Items_ServiceId",
                table: "InvoiceServices",
                column: "ServiceId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceServices_Products_ProductId",
                table: "InvoiceServices");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceServices_Items_ServiceId",
                table: "InvoiceServices");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceServices_ProductId",
                table: "InvoiceServices");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "InvoiceServices");

            migrationBuilder.DropColumn(
                name: "InvoiceType",
                table: "Invoices");

            migrationBuilder.AlterColumn<int>(
                name: "ServiceId",
                table: "InvoiceServices",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceServices_Items_ServiceId",
                table: "InvoiceServices",
                column: "ServiceId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
