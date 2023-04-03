using Microsoft.EntityFrameworkCore.Migrations;

namespace QLNH_APIs.Migrations
{
    public partial class Item2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_CreatedUserId",
                table: "Item",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_RestaurantId",
                table: "Item",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_UpdatedUserId",
                table: "Item",
                column: "UpdatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Restaurant_RestaurantId",
                table: "Item",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_User_CreatedUserId",
                table: "Item",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_User_UpdatedUserId",
                table: "Item",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Restaurant_RestaurantId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_CreatedUserId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_User_UpdatedUserId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_CreatedUserId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_RestaurantId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_UpdatedUserId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Item");
        }
    }
}
