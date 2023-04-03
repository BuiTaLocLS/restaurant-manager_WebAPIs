using Microsoft.EntityFrameworkCore.Migrations;

namespace QLNH_APIs.Migrations
{
    public partial class AddCreatedAndUpdatedUserForRestaurant1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Restaurant",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_UpdatedUserId",
                table: "Restaurant",
                column: "UpdatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_User_UpdatedUserId",
                table: "Restaurant",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_User_UpdatedUserId",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_UpdatedUserId",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Restaurant");
        }
    }
}
