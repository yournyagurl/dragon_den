using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dragon.Migrations
{
    public partial class CheckoutItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_checkouts",
                table: "checkouts");

            migrationBuilder.RenameTable(
                name: "checkouts",
                newName: "CheckoutItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckoutItems",
                table: "CheckoutItems",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckoutItems",
                table: "CheckoutItems");

            migrationBuilder.RenameTable(
                name: "CheckoutItems",
                newName: "checkouts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_checkouts",
                table: "checkouts",
                column: "Id");
        }
    }
}
