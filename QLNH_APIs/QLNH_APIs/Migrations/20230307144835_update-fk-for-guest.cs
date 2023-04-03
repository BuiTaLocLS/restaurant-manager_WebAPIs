using Microsoft.EntityFrameworkCore.Migrations;

namespace QLNH_APIs.Migrations
{
    public partial class updatefkforguest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Guest",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Guest",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Guest",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guest_CreatedUserId",
                table: "Guest",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_RestaurantId",
                table: "Guest",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_UpdatedUserId",
                table: "Guest",
                column: "UpdatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_Restaurant_RestaurantId",
                table: "Guest",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_User_CreatedUserId",
                table: "Guest",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guest_User_UpdatedUserId",
                table: "Guest",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guest_Restaurant_RestaurantId",
                table: "Guest");

            migrationBuilder.DropForeignKey(
                name: "FK_Guest_User_CreatedUserId",
                table: "Guest");

            migrationBuilder.DropForeignKey(
                name: "FK_Guest_User_UpdatedUserId",
                table: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_Guest_CreatedUserId",
                table: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_Guest_RestaurantId",
                table: "Guest");

            migrationBuilder.DropIndex(
                name: "IX_Guest_UpdatedUserId",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Guest");
        }
    }
}
