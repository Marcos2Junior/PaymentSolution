using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentSolution.Infrastructure.Migrations
{
    public partial class AddUserAccesses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "PaymentServiceType",
                table: "PaymentServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "PaymentInstallments",
                type: "decimal(19,4)",
                precision: 19,
                scale: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentServiceType",
                table: "PaymentServices");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "PaymentInstallments",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(19,4)",
                oldPrecision: 19,
                oldScale: 4);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateTime", "Email", "Name", "Password" },
                values: new object[] { 1, new DateTime(2022, 10, 1, 14, 35, 14, 572, DateTimeKind.Utc).AddTicks(8094), "mod.gluguer@gmail.com", "Marcos Antonio dos Santos Junior", "1ARVn2Auq2/WAqx2gNrL+q3RNjAzXpUfCXrzkA6d4Xa22yhRLy4AC50E+6UTPoscbo31nbOoq51gvkuXzJ6B2w==" });
        }
    }
}
