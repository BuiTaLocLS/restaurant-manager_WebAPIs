using Microsoft.EntityFrameworkCore.Migrations;

namespace QLNH_APIs.Migrations
{
    public partial class Item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Category_CategoryId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Unit_UnitId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemImage_Item_ItemId",
                table: "ItemImage");

            migrationBuilder.DropIndex(
                name: "IX_ItemImage_ItemId",
                table: "ItemImage");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ItemImage");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "Item",
                newName: "SizeId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Item",
                newName: "FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_UnitId",
                table: "Item",
                newName: "IX_Item_SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_CategoryId",
                table: "Item",
                newName: "IX_Item_FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Food_FoodId",
                table: "Item",
                column: "FoodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Size_SizeId",
                table: "Item",
                column: "SizeId",
                principalTable: "Size",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Food_FoodId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_Size_SizeId",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "SizeId",
                table: "Item",
                newName: "UnitId");

            migrationBuilder.RenameColumn(
                name: "FoodId",
                table: "Item",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_SizeId",
                table: "Item",
                newName: "IX_Item_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_FoodId",
                table: "Item",
                newName: "IX_Item_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "ItemImage",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemImage_ItemId",
                table: "ItemImage",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Category_CategoryId",
                table: "Item",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Unit_UnitId",
                table: "Item",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemImage_Item_ItemId",
                table: "ItemImage",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
