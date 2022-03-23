using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IoTBay.Migrations
{
    public partial class DecimalWarnFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ExpiryYear",
                table: "PaymentDetails",
                type: "decimal(4)",
                precision: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,2)",
                oldPrecision: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "ExpiryMonth",
                table: "PaymentDetails",
                type: "decimal(2)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)",
                oldPrecision: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "CardNumber",
                table: "PaymentDetails",
                type: "decimal(16)",
                precision: 16,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16,2)",
                oldPrecision: 16);

            migrationBuilder.AlterColumn<decimal>(
                name: "CardCvc",
                table: "PaymentDetails",
                type: "decimal(3)",
                precision: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldPrecision: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ExpiryYear",
                table: "PaymentDetails",
                type: "decimal(4,2)",
                precision: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4)",
                oldPrecision: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "ExpiryMonth",
                table: "PaymentDetails",
                type: "decimal(2,2)",
                precision: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2)",
                oldPrecision: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "CardNumber",
                table: "PaymentDetails",
                type: "decimal(16,2)",
                precision: 16,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16)",
                oldPrecision: 16);

            migrationBuilder.AlterColumn<decimal>(
                name: "CardCvc",
                table: "PaymentDetails",
                type: "decimal(3,2)",
                precision: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3)",
                oldPrecision: 3);
        }
    }
}
