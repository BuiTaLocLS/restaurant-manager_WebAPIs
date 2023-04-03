using Microsoft.EntityFrameworkCore.Migrations;

namespace QLNH_APIs.Migrations
{
    public partial class addDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_User_CreatedUserId",
                table: "Restaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_User_UpdatedUserId",
                table: "Restaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "UserDBSet");

            migrationBuilder.RenameIndex(
                name: "IX_User_RoleId",
                table: "UserDBSet",
                newName: "IX_UserDBSet_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDBSet",
                table: "UserDBSet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_UserDBSet_CreatedUserId",
                table: "Restaurant",
                column: "CreatedUserId",
                principalTable: "UserDBSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_UserDBSet_UpdatedUserId",
                table: "Restaurant",
                column: "UpdatedUserId",
                principalTable: "UserDBSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDBSet_Role_RoleId",
                table: "UserDBSet",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_UserDBSet_CreatedUserId",
                table: "Restaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_UserDBSet_UpdatedUserId",
                table: "Restaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDBSet_Role_RoleId",
                table: "UserDBSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDBSet",
                table: "UserDBSet");

            migrationBuilder.RenameTable(
                name: "UserDBSet",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_UserDBSet_RoleId",
                table: "User",
                newName: "IX_User_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_User_CreatedUserId",
                table: "Restaurant",
                column: "CreatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_User_UpdatedUserId",
                table: "Restaurant",
                column: "UpdatedUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
