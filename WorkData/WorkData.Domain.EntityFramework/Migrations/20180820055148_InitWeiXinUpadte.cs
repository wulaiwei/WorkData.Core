using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace WorkData.Domain.EntityFramework.Migrations
{
    public partial class InitWeiXinUpadte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "WeiXinShare",
                type: "timestamp(0)",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "WeiXinShare",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp(0)");
        }
    }
}