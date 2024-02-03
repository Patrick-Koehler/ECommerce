using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriCommerce.Models;

[Table ("Invoice")]
public class Invoice
{
    [Key]
    [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }
    
    public required Guid CustomerId { get; set; }

    [Column(TypeName ="smalldatetime")]
    public required DateTime Created { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime Modified { get; set; }

}
