namespace ECommerce.Models.Dtos;

public class CustomerDto
{
    public required int CustomerNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public int? Zip { get; set; }
    public string? Phonenumber { get; set; }
    public string? Email { get; set; }
    public DateOnly Birthday { get; set; }
    public DateOnly CustomerSince { get; set; }
    public string? Info { get; set; }
    public bool IsOneTimeCustomer { get; set; }
}
