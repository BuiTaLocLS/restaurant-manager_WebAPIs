using Microsoft.EntityFrameworkCore.Migrations;

namespace QLNH_APIs.Migrations
{
    public partial class AddCreatedAndUpdatedUserForRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Restaurant",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_CreatedUserId",
                table: "Restaurant",
                column: "CreatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_User_CreatedUserId",
                table: "Restaurant",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_User_CreatedUserId",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_CreatedUserId",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Restaurant");
        }
    }
}
