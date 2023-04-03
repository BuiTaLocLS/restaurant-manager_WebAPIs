using Microsoft.EntityFrameworkCore.Migrations;

namespace QLNH_APIs.Migrations
{
    public partial class UpdateImageForFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemImageId",
                table: "Food",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Food_ItemImageId",
                table: "Food",
                column: "ItemImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_ItemImage_ItemImageId",
                table: "Food",
                column: "ItemImageId",
                principalTable: "ItemImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_ItemImage_ItemImageId",
                table: "Food");

            migrationBuilder.DropIndex(
                name: "IX_Food_ItemImageId",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "ItemImageId",
                table: "Food");
        }
    }
}
