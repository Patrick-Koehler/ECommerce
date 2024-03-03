namespace ECommerce.Models.Dtos;

public class ShipmentItemDto
{
    public required string ProductNumber { get; set; }

    public required string Description { get; set; }

    public double Quantity { get; set; }

    public SerialNumberListDto? SerialNumberList { get; set; }
}
