using Microsoft.EntityFrameworkCore.Migrations;

namespace QLNH_APIs.Migrations
{
    public partial class updatefkforstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Status",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Status",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Status",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Status_CreatedUserId",
                table: "Status",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_RestaurantId",
                table: "Status",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_UpdatedUserId",
                table: "Status",
                column: "UpdatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Status_Restaurant_RestaurantId",
                table: "Status",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Status_User_CreatedUserId",
                table: "Status",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Status_User_UpdatedUserId",
                table: "Status",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Status_Restaurant_RestaurantId",
                table: "Status");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_User_CreatedUserId",
                table: "Status");

            migrationBuilder.DropForeignKey(
                name: "FK_Status_User_UpdatedUserId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Status_CreatedUserId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Status_RestaurantId",
                table: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Status_UpdatedUserId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Status");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Status");
        }
    }
}
