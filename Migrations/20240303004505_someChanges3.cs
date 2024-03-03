using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Migrations
{
    /// <inheritdoc />
    public partial class someChanges3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SerialNumberList",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false),
                    FrameNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Serialnumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BatteryNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductionNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SerialNumberDisplay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KeyNumberFrameLock = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KeyNumberBattery = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MotorNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GearHubNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Created = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialNumberList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeliveryAdressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Modified = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SerialNumberList");

            migrationBuilder.DropTable(
                name: "ShipmentItem");

            migrationBuilder.DropTable(
                name: "Shipments");
        }
    }
}
