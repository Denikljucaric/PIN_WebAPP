using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PIN_WebAPP.Data.Migrations
{
    public partial class pictures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Product");

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Product",
                nullable: true);
        }
    }
}
