using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

[Table("ProductInformation")]
public class ProductInformation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string ProductNumber { get; set; } = null!;
    public string? ProductName { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime Created { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime Modified { get; set; }
}
