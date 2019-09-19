using Microsoft.EntityFrameworkCore.Migrations;

namespace PIN_WebAPP.Data.Migrations
{
    public partial class maleizmjene : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShopingCart",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ShopingCart",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
