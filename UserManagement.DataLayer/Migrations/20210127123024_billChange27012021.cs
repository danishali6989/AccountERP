using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class billChange27012021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillServices_Items_ItemId",
                table: "BillServices");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "BillServices",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "BillServices",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BillType",
                table: "Bills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BillServices_ProductId",
                table: "BillServices",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillServices_Items_ItemId",
                table: "BillServices",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BillServices_Products_ProductId",
                table: "BillServices",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillServices_Items_ItemId",
                table: "BillServices");

            migrationBuilder.DropForeignKey(
                name: "FK_BillServices_Products_ProductId",
                table: "BillServices");

            migrationBuilder.DropIndex(
                name: "IX_BillServices_ProductId",
                table: "BillServices");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "BillServices");

            migrationBuilder.DropColumn(
                name: "BillType",
                table: "Bills");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "BillServices",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BillServices_Items_ItemId",
                table: "BillServices",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
