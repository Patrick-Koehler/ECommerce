using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class addedAndChangedModels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductInformation");

            migrationBuilder.AddColumn<DateTime>(
                name: "AvailableFrom",
                table: "Product",
                type: "smalldatetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Product",
                type: "smalldatetime",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Product",
                type: "smalldatetime",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EAN = table.Column<int>(type: "int", nullable: true),
                    ManufacturerNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropColumn(
                name: "AvailableFrom",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Product");

            migrationBuilder.AlterColumn<decimal>(
                name: "RetailPrice",
                table: "Product",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "RRP",
                table: "Product",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modified = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInformation", x => x.Id);
                });
        }
    }
}
