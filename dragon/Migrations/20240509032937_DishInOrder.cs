using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dragon.Migrations
{
    public partial class DishInOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_orderItems_DishId",
                table: "orderItems",
                column: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderItems_Dish_DishId",
                table: "orderItems",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderItems_Dish_DishId",
                table: "orderItems");

            migrationBuilder.DropIndex(
                name: "IX_orderItems_DishId",
                table: "orderItems");
        }
    }
}
