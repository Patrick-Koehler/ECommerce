﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models;

[Table("Customer")]
public class Customer
{
    [Key]
    public required Guid Id { get; set; }

    public required string CustomerNumber { get; set; }
    
    [StringLength(50)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    public string? LastName { get; set; }

    [StringLength(50)]
    public string? Street { get; set; }

    [StringLength(30)]
    public string? City { get; set; }

    public int? Zip { get; set; }

    public string? Phonenumber { get; set; }

    public string? Email { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime Birthday { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime CustomerSince { get; set; }

    [StringLength(500)]
    public string? Info { get; set; }

    public bool IsOneTimeCustomer { get; set; }

    public string? UserId { get; set; }

    public string? UserPassword { get; set; }

    [Column(TypeName = "smalldatetime")]
    public required DateTime Created { get; set; }

    [Column(TypeName = "smalldatetime")]
    public DateTime? Modified { get; set; }
}
