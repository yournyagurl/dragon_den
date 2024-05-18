using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dragon.Migrations
{
    public partial class AdUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Ads");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ads",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ads");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
