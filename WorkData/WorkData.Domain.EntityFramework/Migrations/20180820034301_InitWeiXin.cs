using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WorkData.Domain.EntityFramework.Migrations
{
    public partial class InitWeiXin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeiXinShare",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    ShareOpenId = table.Column<string>(maxLength: 300, nullable: false),
                    ShareOpenNick = table.Column<string>(maxLength: 300, nullable: false),
                    LikeOpenId = table.Column<string>(maxLength: 300, nullable: false),
                    LikeOpenNick = table.Column<string>(maxLength: 300, nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeiXinShare", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeiXinShare");
        }
    }
}