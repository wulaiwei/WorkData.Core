using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkData.Domain.EntityFramework.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseRole",
                columns: table => new
                {
                    CreateTime = table.Column<DateTime>(type: "timestamp(0)", nullable: false),
                    CreateUserId = table.Column<string>(maxLength: 200, nullable: true),
                    ModifierTime = table.Column<DateTime>(type: "timestamp(0)", nullable: true),
                    ModifierUserId = table.Column<string>(maxLength: 200, nullable: true),
                    BelongUserId = table.Column<string>(maxLength: 200, nullable: true),
                    MemberUserId = table.Column<string>(maxLength: 200, nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    RoleName = table.Column<string>(maxLength: 150, nullable: true),
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseUser",
                columns: table => new
                {
                    CreateTime = table.Column<DateTime>(type: "timestamp(0)", nullable: false),
                    CreateUserId = table.Column<string>(maxLength: 200, nullable: true),
                    ModifierTime = table.Column<DateTime>(type: "timestamp(0)", nullable: true),
                    ModifierUserId = table.Column<string>(maxLength: 200, nullable: true),
                    BelongUserId = table.Column<string>(maxLength: 200, nullable: true),
                    MemberUserId = table.Column<string>(maxLength: 200, nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 150, nullable: true),
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseUserMember",
                columns: table => new
                {
                    CreateTime = table.Column<DateTime>(type: "timestamp(0)", nullable: false),
                    CreateUserId = table.Column<string>(maxLength: 200, nullable: true),
                    ModifierTime = table.Column<DateTime>(type: "timestamp(0)", nullable: true),
                    ModifierUserId = table.Column<string>(maxLength: 200, nullable: true),
                    BelongUserId = table.Column<string>(maxLength: 200, nullable: true),
                    MemberUserId = table.Column<string>(maxLength: 200, nullable: true),
                    IsDelete = table.Column<bool>(nullable: false),
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    BaseUserId = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseUserMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseUserMember_BaseUser_BaseUserId",
                        column: x => x.BaseUserId,
                        principalTable: "BaseUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_BaseUserMember_BaseUserId",
                table: "BaseUserMember",
                column: "BaseUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_BaseUserId",
                table: "UserRoles",
                column: "BaseUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseUserMember");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "BaseRole");

            migrationBuilder.DropTable(
                name: "BaseUser");
        }
    }
}
