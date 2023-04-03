using Microsoft.EntityFrameworkCore.Migrations;

namespace QLNH_APIs.Migrations
{
    public partial class UpdateTableLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Location",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Location",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Location",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_CreatedUserId",
                table: "Location",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_RestaurantId",
                table: "Location",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_UpdatedUserId",
                table: "Location",
                column: "UpdatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Restaurant_RestaurantId",
                table: "Location",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_User_CreatedUserId",
                table: "Location",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Location_User_UpdatedUserId",
                table: "Location",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Restaurant_RestaurantId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_User_CreatedUserId",
                table: "Location");

            migrationBuilder.DropForeignKey(
                name: "FK_Location_User_UpdatedUserId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_CreatedUserId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_RestaurantId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_UpdatedUserId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Location");
        }
    }
}
