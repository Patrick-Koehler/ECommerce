﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

[Table("ProductColor")]
public class ProductColor
{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }

    public required string Description { get; set; }

    [Column(TypeName = "smalldatetime")]
    public required DateTime Created { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? Modified { get; set; }
}