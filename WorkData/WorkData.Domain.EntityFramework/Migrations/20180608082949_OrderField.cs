using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkData.Domain.EntityFramework.Migrations
{
    public partial class OrderField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_BaseRole_BaseRoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_BaseUser_BaseUserId",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "UserRole");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_BaseUserId",
                table: "UserRole",
                newName: "IX_UserRole_BaseUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole",
                columns: new[] { "BaseRoleId", "BaseUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_BaseRole_BaseRoleId",
                table: "UserRole",
                column: "BaseRoleId",
                principalTable: "BaseRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_BaseUser_BaseUserId",
                table: "UserRole",
                column: "BaseUserId",
                principalTable: "BaseUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_BaseRole_BaseRoleId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_BaseUser_BaseUserId",
                table: "UserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRole",
                table: "UserRole");

            migrationBuilder.RenameTable(
                name: "UserRole",
                newName: "UserRoles");

            migrationBuilder.RenameIndex(
                name: "IX_UserRole_BaseUserId",
                table: "UserRoles",
                newName: "IX_UserRoles_BaseUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "BaseRoleId", "BaseUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_BaseRole_BaseRoleId",
                table: "UserRoles",
                column: "BaseRoleId",
                principalTable: "BaseRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_BaseUser_BaseUserId",
                table: "UserRoles",
                column: "BaseUserId",
                principalTable: "BaseUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}