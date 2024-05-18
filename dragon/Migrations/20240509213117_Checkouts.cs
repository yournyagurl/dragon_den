using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dragon.Migrations
{
    public partial class Checkouts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CheckoutItems",
                table: "CheckoutItems");

            migrationBuilder.RenameTable(
                name: "CheckoutItems",
                newName: "Checkouts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checkouts",
                table: "Checkouts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Checkouts",
                table: "Checkouts");

            migrationBuilder.RenameTable(
                name: "Checkouts",
                newName: "CheckoutItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CheckoutItems",
                table: "CheckoutItems",
                column: "Id");
        }
    }
}
