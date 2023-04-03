using Microsoft.EntityFrameworkCore.Migrations;

namespace QLNH_APIs.Migrations
{
    public partial class GuestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "GuestTable",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "GuestTable",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "GuestTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuestTable_CreatedUserId",
                table: "GuestTable",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestTable_RestaurantId",
                table: "GuestTable",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestTable_UpdatedUserId",
                table: "GuestTable",
                column: "UpdatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestTable_Restaurant_RestaurantId",
                table: "GuestTable",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestTable_User_CreatedUserId",
                table: "GuestTable",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestTable_User_UpdatedUserId",
                table: "GuestTable",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestTable_Restaurant_RestaurantId",
                table: "GuestTable");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestTable_User_CreatedUserId",
                table: "GuestTable");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestTable_User_UpdatedUserId",
                table: "GuestTable");

            migrationBuilder.DropIndex(
                name: "IX_GuestTable_CreatedUserId",
                table: "GuestTable");

            migrationBuilder.DropIndex(
                name: "IX_GuestTable_RestaurantId",
                table: "GuestTable");

            migrationBuilder.DropIndex(
                name: "IX_GuestTable_UpdatedUserId",
                table: "GuestTable");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "GuestTable");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "GuestTable");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "GuestTable");
        }
    }
}
