using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ValidationWithMediatr_task.Migrations
{
    public partial class newInitialCreates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Customer");

            migrationBuilder.AddColumn<DateTime>(
                name: "birthdate",
                table: "Customer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Product_merchant_id",
                table: "Product",
                column: "merchant_id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Payment_Cards_customer_id",
                table: "Customer_Payment_Cards",
                column: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Payment_Cards_Customer_customer_id",
                table: "Customer_Payment_Cards",
                column: "customer_id",
                principalTable: "Customer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Merchants_merchant_id",
                table: "Product",
                column: "merchant_id",
                principalTable: "Merchants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Payment_Cards_Customer_customer_id",
                table: "Customer_Payment_Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Merchants_merchant_id",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_merchant_id",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Customer_Payment_Cards_customer_id",
                table: "Customer_Payment_Cards");

            migrationBuilder.DropColumn(
                name: "birthdate",
                table: "Customer");

            migrationBuilder.AddColumn<DateTime>(
                name: "MyProperty",
                table: "Customer",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
