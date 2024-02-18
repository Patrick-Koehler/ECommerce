using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

[Table("Customer")]
public class Customer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }

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

    [Column(TypeName = "smalldatetime")]
    public required DateTime Created { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? Modified { get; set; }
}
