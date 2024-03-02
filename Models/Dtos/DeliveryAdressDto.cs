namespace ECommerce.Models.Dtos;

public class DeliveryAdressDto
{
    public required Guid CustomerId { get; set; }
    
    public required string CustomerNumber { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public int? Zip { get; set; }

    public string? Phonenumber { get; set; }

    public string? Email { get; set; }

    public required bool IsMain { get; set; } = false;
}
