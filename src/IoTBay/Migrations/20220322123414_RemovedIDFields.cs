using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IoTBay.Migrations
{
    public partial class RemovedIDFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_Users_CustomerId",
                table: "PaymentDetails");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "PaymentDetails",
                newName: "CustomerUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentDetails_CustomerId",
                table: "PaymentDetails",
                newName: "IX_PaymentDetails_CustomerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_Users_CustomerUserId",
                table: "PaymentDetails",
                column: "CustomerUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDetails_Users_CustomerUserId",
                table: "PaymentDetails");

            migrationBuilder.RenameColumn(
                name: "CustomerUserId",
                table: "PaymentDetails",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentDetails_CustomerUserId",
                table: "PaymentDetails",
                newName: "IX_PaymentDetails_CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDetails_Users_CustomerId",
                table: "PaymentDetails",
                column: "CustomerId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
