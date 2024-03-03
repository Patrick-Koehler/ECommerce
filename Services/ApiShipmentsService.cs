using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Models.Dtos;
using ECommerce.Services.Interfaces;

namespace ECommerce.Services
{
    public class ApiShipmentsService : IApiShipmentsService
    {
        public readonly ECommerceDbContext _context;
        public ApiShipmentsService(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task AddNewShipmentAsync(ShipmentDto newShipment)
        {
            Shipment shipment = new()
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                DeliveryAdressId = Guid.NewGuid(),
                ShipmentNumber = newShipment.ShipmentNumber,
                OrderNumber = newShipment.OrderNumber,
                Created = DateTime.Now,
                Modified = null
            };
            await _context.Shipments.AddAsync(shipment);

            foreach (var newShipmentItem in newShipment.ShipmentItem)
            {
                ShipmentItem shipmentItem = new()
                {
                    Id = Guid.NewGuid(),
                    ProductId = Guid.NewGuid(),
                    ProductNumber = newShipmentItem.ProductNumber,
                    Description = newShipmentItem.Description,
                    Quantity = newShipmentItem.Quantity,
                    Created = DateTime.Now,
                    Modified = null
                };
                await _context.ShipmentItems.AddAsync(shipmentItem);
                
                if (newShipmentItem.SerialNumberList != null)
                {
                    SerialNumberList serialNumberList = new()
                    {
                        Id = Guid.NewGuid(),
                        ShipmentItemId = shipmentItem.Id,
                        CustomerId = shipment.CustomerId,
                        ProductionNumber = newShipmentItem.SerialNumberList.ProductionNumber,
                        FrameNumber = newShipmentItem.SerialNumberList.FrameNumber,
                        Serialnumber = newShipmentItem.SerialNumberList.Serialnumber,
                        SerialNumberDisplay = newShipmentItem.SerialNumberList.SerialNumberDisplay,
                        BatteryNumber = newShipmentItem.SerialNumberList.BatteryNumber,
                        KeyNumberFrameLock = newShipmentItem.SerialNumberList.KeyNumberFrameLock,
                        KeyNumberBattery = newShipmentItem.SerialNumberList.KeyNumberBattery,
                        MotorNumber = newShipmentItem.SerialNumberList.MotorNumber,
                        GearHubNumber = newShipmentItem.SerialNumberList.GearHubNumber,
                        Created = DateTime.Now
                    };
                    await _context.SerialNumberLists.AddAsync(serialNumberList);
                }
            }
            
            await _context.SaveChangesAsync();
        }
    }
}
