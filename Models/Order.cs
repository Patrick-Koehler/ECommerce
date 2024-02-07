using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

[Table("Order")]
public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public bool IsNew { get; set; }
    public bool IsCompleted { get; set; }
    public string? OrderState { get; set; }
    public string? Payment { get; set; }
    public string? Notice { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime OrderImportDate { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime Created { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? Modified { get; set; }
}
