namespace ECommerce.Models.Dtos;

public class OrderDto
{
    public required CustomerDto Customer { get; set; }
    public required OrderItemDto OrderItems { get; set; }
    public string? Payment { get; set; }
    public required bool IsPayed { get; set; }
    public string? Reference { get; set; }
    public string? Notice { get; set; }
    public string? TrackingNumber { get; set; }
}