using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WorkData.Domain.EntityFramework.Migrations
{
    public partial class CreateIdentityDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseRole",
                columns: table => new
                {
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(maxLength: 500, nullable: true),
                    ModifierTime = table.Column<DateTime>(nullable: true),
                    ModifierUserId = table.Column<string>(maxLength: 500, nullable: true),
                    BelongUserId = table.Column<string>(maxLength: 500, nullable: true),
                    MemberUserId = table.Column<string>(maxLength: 500, nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: true),
                    Id = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseUser",
                columns: table => new
                {
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(maxLength: 500, nullable: true),
                    ModifierTime = table.Column<DateTime>(nullable: true),
                    ModifierUserId = table.Column<string>(maxLength: 500, nullable: true),
                    BelongUserId = table.Column<string>(maxLength: 500, nullable: true),
                    MemberUserId = table.Column<string>(maxLength: 500, nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Id = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    BaseUserId = table.Column<string>(maxLength: 128, nullable: false),
                    BaseRoleId = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.BaseRoleId, x.BaseUserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_BaseRole_BaseRoleId",
                        column: x => x.BaseRoleId,
                        principalTable: "BaseRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_BaseUser_BaseUserId",
                        column: x => x.BaseUserId,
                        principalTable: "BaseUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_BaseUserId",
                table: "UserRoles",
                column: "BaseUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "BaseRole");

            migrationBuilder.DropTable(
                name: "BaseUser");
        }
    }
}