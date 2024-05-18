using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dragon.Migrations
{
    public partial class moreUpdatesForOrderHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderHistoryOrderNo",
                table: "orderItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_OrderHistoryOrderNo",
                table: "orderItems",
                column: "OrderHistoryOrderNo");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_OrderHistorys_OrderHistoryOrderNo",
                table: "orderItems",
                column: "OrderHistoryOrderNo",
                principalTable: "OrderHistorys",
                principalColumn: "OrderNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_OrderHistorys_OrderHistoryOrderNo",
                table: "orderItems");

            migrationBuilder.DropIndex(
                name: "IX_orderItems_OrderHistoryOrderNo",
                table: "orderItems");

            migrationBuilder.DropColumn(
                name: "OrderHistoryOrderNo",
                table: "orderItems");
        }
    }
}
