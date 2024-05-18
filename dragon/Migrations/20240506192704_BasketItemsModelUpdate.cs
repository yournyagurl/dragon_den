using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dragon.Migrations
{
    public partial class BasketItemsModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Dish_DishId",
                table: "BasketItems",
                column: "DishId",
                principalTable: "Dish",
                principalColumn: "DishId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Dish_DishId",
                table: "BasketItems");
        }
    }
}
