using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QLNH_APIs.Migrations
{
    public partial class AddTableSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedUserId",
                table: "Unit",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedUserId",
                table: "Unit",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    RestaurantId = table.Column<int>(type: "int", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Size_Restaurant_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Size_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Size_User_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Size_User_UpdatedUserId",
                        column: x => x.UpdatedUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Unit_CreatedUserId",
                table: "Unit",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_UpdatedUserId",
                table: "Unit",
                column: "UpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Size_CreatedUserId",
                table: "Size",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Size_RestaurantId",
                table: "Size",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Size_UnitId",
                table: "Size",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Size_UpdatedUserId",
                table: "Size",
                column: "UpdatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_User_CreatedUserId",
                table: "Unit",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_User_UpdatedUserId",
                table: "Unit",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Unit_User_CreatedUserId",
                table: "Unit");

            migrationBuilder.DropForeignKey(
                name: "FK_Unit_User_UpdatedUserId",
                table: "Unit");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropIndex(
                name: "IX_Unit_CreatedUserId",
                table: "Unit");

            migrationBuilder.DropIndex(
                name: "IX_Unit_UpdatedUserId",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "CreatedUserId",
                table: "Unit");

            migrationBuilder.DropColumn(
                name: "UpdatedUserId",
                table: "Unit");
        }
    }
}
