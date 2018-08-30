using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkData.Domain.EntityFramework.Migrations
{
    public partial class INITWEIXINUSERINFO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeiXinUserInfo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    OpenId = table.Column<string>(maxLength: 300, nullable: false),
                    NickName = table.Column<string>(maxLength: 300, nullable: false),
                    Country = table.Column<string>(maxLength: 300, nullable: false),
                    Sex = table.Column<string>(maxLength: 300, nullable: false),
                    Province = table.Column<string>(maxLength: 300, nullable: false),
                    HeadImgUrl = table.Column<string>(maxLength: 300, nullable: false),
                    City = table.Column<string>(maxLength: 300, nullable: false),
                    UnionId = table.Column<string>(maxLength: 300, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp(0)", nullable: false),
                    CreateUserId = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeiXinUserInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeiXinUserInfo");
        }
    }
}
