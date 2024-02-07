using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriCommerce.Models;

[Table("ErrorMessage")]
public class ErrorMessage
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? SellersItemIdentification { get; set; }

    [Unicode(false)]
    public string? Message { get; set; }

    public int? ErrorCode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FunctionName { get; set; }

    [Unicode(false)]
    public string? InnerException { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Password { get; set; }

    public bool? IsTest { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RequestType { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? RequestData { get; set; }

    public Guid? TransactionId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UserAgent { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime Created { get; set; }
}
