namespace ECommerce.Models.Dtos;

public class OrderDto
{
    public string? Payment { get; set; }
    public required bool IsPayed { get; set; }
    public string? Reference { get; set; }
    public string? Notice { get; set; }
    public string? TrackingNumber { get; set; }
}