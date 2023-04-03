using Microsoft.EntityFrameworkCore.Migrations;

namespace QLNH_APIs.Migrations
{
    public partial class ImageItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "ItemImage",
                newName: "Base64");

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "ItemImage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "ItemImage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "ItemImage",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemImage_CreatedUserId",
                table: "ItemImage",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemImage_RestaurantId",
                table: "ItemImage",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemImage_UpdatedUserId",
                table: "ItemImage",
                column: "UpdatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemImage_Restaurant_RestaurantId",
                table: "ItemImage",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemImage_User_CreatedUserId",
                table: "ItemImage",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemImage_User_UpdatedUserId",
                table: "ItemImage",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemImage_Restaurant_RestaurantId",
                table: "ItemImage");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemImage_User_CreatedUserId",
                table: "ItemImage");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemImage_User_UpdatedUserId",
                table: "ItemImage");

            migrationBuilder.DropIndex(
                name: "IX_ItemImage_CreatedUserId",
                table: "ItemImage");

            migrationBuilder.DropIndex(
                name: "IX_ItemImage_RestaurantId",
                table: "ItemImage");

            migrationBuilder.DropIndex(
                name: "IX_ItemImage_UpdatedUserId",
                table: "ItemImage");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "ItemImage");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "ItemImage");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "ItemImage");

            migrationBuilder.RenameColumn(
                name: "Base64",
                table: "ItemImage",
                newName: "Data");
        }
    }
}
