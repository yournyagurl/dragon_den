using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dragon.Migrations
{
    public partial class DropHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_orderHistories",
                table: "orderHistories");

            migrationBuilder.RenameTable(
                name: "orderHistories",
                newName: "OrderHistorys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderHistorys",
                table: "OrderHistorys",
                column: "OrderNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderHistorys",
                table: "OrderHistorys");

            migrationBuilder.RenameTable(
                name: "OrderHistorys",
                newName: "orderHistories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderHistories",
                table: "orderHistories",
                column: "OrderNo");
        }
    }
}
