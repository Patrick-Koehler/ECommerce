using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ECommerce.Models;

[Table("ClassificationSchemeGroup")]
public partial class ClassificationSchemeGroup
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public required string Description { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime Created { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime Modified { get; set; }
}
