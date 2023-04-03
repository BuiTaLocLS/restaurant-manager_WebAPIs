using Microsoft.EntityFrameworkCore.Migrations;

namespace QLNH_APIs.Migrations
{
    public partial class removeResFromOrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Restaurant_RestaurantId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_RestaurantId",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "OrderItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "OrderItem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_RestaurantId",
                table: "OrderItem",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Restaurant_RestaurantId",
                table: "OrderItem",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
