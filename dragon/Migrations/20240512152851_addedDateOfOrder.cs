using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dragon.Migrations
{
    public partial class addedDateOfOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOrder",
                table: "OrderHistorys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfOrder",
                table: "OrderHistorys");
        }
    }
}
