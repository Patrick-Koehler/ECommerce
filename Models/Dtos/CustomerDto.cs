namespace ECommerce.Models.Dtos;

public class CustomerDto
{
    public required string CustomerNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public int? Zip { get; set; }
    public string? Phonenumber { get; set; }
    public string? Email { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime CustomerSince { get; set; }
    public string? Info { get; set; }
    public bool IsOneTimeCustomer { get; set; }
    public string? UserId { get; set; }
    public string? UserPassword { get; set; }
    public DeliveryAdressDto? DeliveryAdress { get; set; }
}
