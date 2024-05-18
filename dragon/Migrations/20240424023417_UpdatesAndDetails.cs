using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dragon.Migrations
{
    public partial class UpdatesAndDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Category_CategoryId",
                table: "Dishes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes");

            migrationBuilder.RenameTable(
                name: "Dishes",
                newName: "Dish");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_CategoryId",
                table: "Dish",
                newName: "IX_Dish_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dish",
                table: "Dish",
                column: "DishId");

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    BasketId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => new { x.DishId, x.BasketId });
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    BasketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.BasketId);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutCustomers",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutCustomers", x => x.Email);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Dish_Category_CategoryId",
                table: "Dish",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dish_Category_CategoryId",
                table: "Dish");

            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "CheckoutCustomers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dish",
                table: "Dish");

            migrationBuilder.RenameTable(
                name: "Dish",
                newName: "Dishes");

            migrationBuilder.RenameIndex(
                name: "IX_Dish_CategoryId",
                table: "Dishes",
                newName: "IX_Dishes_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes",
                column: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Category_CategoryId",
                table: "Dishes",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
