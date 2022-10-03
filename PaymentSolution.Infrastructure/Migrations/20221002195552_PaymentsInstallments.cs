using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentSolution.Infrastructure.Migrations
{
    public partial class PaymentsInstallments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Payments");

            migrationBuilder.AddColumn<DateTime>(
                name: "Expiration",
                table: "PaymentInstallments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "PaymentInstallments",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "Scheduled",
                table: "PaymentInstallments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PaymentInstallments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expiration",
                table: "PaymentInstallments");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "PaymentInstallments");

            migrationBuilder.DropColumn(
                name: "Scheduled",
                table: "PaymentInstallments");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PaymentInstallments");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Payments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
