using Microsoft.EntityFrameworkCore.Migrations;

namespace QLNH_APIs.Migrations
{
    public partial class addrestauranttorole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Role",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Role_RestaurantId",
                table: "Role",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Restaurant_RestaurantId",
                table: "Role",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Restaurant_RestaurantId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_RestaurantId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Role");
        }
    }
}
