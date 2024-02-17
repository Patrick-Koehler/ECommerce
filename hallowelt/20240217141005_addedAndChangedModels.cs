using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class addedAndChangedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "ProductImage",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Payment",
                table: "OrderItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Quantity",
                table: "OrderItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "RetailPrice",
                table: "OrderItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RetailPriceNet",
                table: "OrderItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<double>(
                name: "VAT",
                table: "OrderItem",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<decimal>(
                name: "VATAmount",
                table: "OrderItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "InvoiceItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FrameNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockBranch",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockBranch", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceItem");

            migrationBuilder.DropTable(
                name: "StockBranch");

            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "ProductImage");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "Payment",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "RetailPrice",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "RetailPriceNet",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "VAT",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "VATAmount",
                table: "OrderItem");
        }
    }
}
