using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountErp.DataLayer.Migrations
{
    public partial class _0605202299 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "Usr_LName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "Usr_FName");

            migrationBuilder.AlterColumn<string>(
                name: "Ip_Address",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "App_id",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Usr_LName",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Usr_FName",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "Ip_Address",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "App_id",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
