using Microsoft.EntityFrameworkCore.Migrations;

namespace PIN_WebAPP.Data.Migrations
{
    public partial class AddOrderDetaildAndHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PickUpName",
                table: "OrderHeader",
                newName: "PickupName");

            migrationBuilder.RenameColumn(
                name: "PickUpPhoneNumber",
                table: "OrderHeader",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "OrderTime",
                table: "OrderHeader",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "CoupoPaymentStatusnCode",
                table: "OrderHeader",
                newName: "PaymentStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PickupName",
                table: "OrderHeader",
                newName: "PickUpName");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "OrderHeader",
                newName: "PickUpPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "PaymentStatus",
                table: "OrderHeader",
                newName: "CoupoPaymentStatusnCode");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "OrderHeader",
                newName: "OrderTime");
        }
    }
}
