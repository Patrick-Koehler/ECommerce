using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class someChanges4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "ProductInformation",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ProductDescription2",
                table: "Product",
                newName: "Description2");

            migrationBuilder.RenameColumn(
                name: "ProductDescription",
                table: "Product",
                newName: "Description");

            migrationBuilder.CreateTable(
                name: "ProductSize",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSize", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductSize");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ProductInformation",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "Description2",
                table: "Product",
                newName: "ProductDescription2");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Product",
                newName: "ProductDescription");

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    SizeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                });
        }
    }
}
