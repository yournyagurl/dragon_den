using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dragon.Migrations
{
    public partial class BasketItemChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ads");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "BasketItems");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
