using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class someChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeliveryAdress",
                table: "Order",
                newName: "DeliveryAdressId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Product",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "CustomerNumber",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPassword",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "UserPassword",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "DeliveryAdressId",
                table: "Order",
                newName: "DeliveryAdress");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerNumber",
                table: "Customer",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
