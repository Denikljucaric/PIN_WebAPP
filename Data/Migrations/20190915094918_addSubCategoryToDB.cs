using Microsoft.EntityFrameworkCore.Migrations;

namespace PIN_WebAPP.Data.Migrations
{
    public partial class addSubCategoryToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_Category_CategiryId",
                table: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_SubCategory_CategiryId",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "CategiryId",
                table: "SubCategory");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_Category_CategoryId",
                table: "SubCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_Category_CategoryId",
                table: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory");

            migrationBuilder.AddColumn<int>(
                name: "CategiryId",
                table: "SubCategory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategiryId",
                table: "SubCategory",
                column: "CategiryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_Category_CategiryId",
                table: "SubCategory",
                column: "CategiryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
