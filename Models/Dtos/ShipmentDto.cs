namespace ECommerce.Models.Dtos
{
    public class ShipmentDto
    {
        public required string ShipmentNumber { get; set; }

        public required string OrderNumber { get; set; }

        public required List<ShipmentItemDto> ShipmentItem{ get; set;}
    }
}
