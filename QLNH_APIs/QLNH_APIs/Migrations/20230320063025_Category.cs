using Microsoft.EntityFrameworkCore.Migrations;

namespace QLNH_APIs.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "parentId",
                table: "Category");

            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Category",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_CreatedUserId",
                table: "Category",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_RestaurantId",
                table: "Category",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_UpdatedUserId",
                table: "Category",
                column: "UpdatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Restaurant_RestaurantId",
                table: "Category",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_User_CreatedUserId",
                table: "Category",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_User_UpdatedUserId",
                table: "Category",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Restaurant_RestaurantId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_User_CreatedUserId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_User_UpdatedUserId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_CreatedUserId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_RestaurantId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_UpdatedUserId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Category");

            migrationBuilder.AddColumn<int>(
                name: "parentId",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
