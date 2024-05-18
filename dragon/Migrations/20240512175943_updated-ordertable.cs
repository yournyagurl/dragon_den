using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dragon.Migrations
{
    public partial class updatedordertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateTable(
                name: "itemsOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderHistoryOrderNo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemsOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_itemsOrders_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_itemsOrders_OrderHistorys_OrderHistoryOrderNo",
                        column: x => x.OrderHistoryOrderNo,
                        principalTable: "OrderHistorys",
                        principalColumn: "OrderNo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_itemsOrders_DishId",
                table: "itemsOrders",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_itemsOrders_OrderHistoryOrderNo",
                table: "itemsOrders",
                column: "OrderHistoryOrderNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itemsOrders");

            migrationBuilder.CreateTable(
                name: "orderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishId = table.Column<int>(type: "int", nullable: false),
                    OrderHistoryOrderNo = table.Column<int>(type: "int", nullable: true),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderItems_Dish_DishId",
                        column: x => x.DishId,
                        principalTable: "Dish",
                        principalColumn: "DishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderItems_OrderHistorys_OrderHistoryOrderNo",
                        column: x => x.OrderHistoryOrderNo,
                        principalTable: "OrderHistorys",
                        principalColumn: "OrderNo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_DishId",
                table: "orderItems",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_OrderHistoryOrderNo",
                table: "orderItems",
                column: "OrderHistoryOrderNo");
        }
    }
}
