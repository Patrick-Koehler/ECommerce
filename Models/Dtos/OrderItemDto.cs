namespace ECommerce.Models.Dtos;

public class OrderItemDto
{
    public required string ProductNumber { get; set; }

    public required string Description { get; set; }

    public double Quantity { get; set; }

    public required decimal RetailPriceNet { get; set; }

    public required decimal RetailPrice { get; set; }

    public required double VAT { get; set; }

    public required decimal VATAmount { get; set; }

    public required string Payment { get; set; }

}
