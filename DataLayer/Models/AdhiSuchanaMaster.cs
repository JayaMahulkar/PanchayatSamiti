using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Models;

[Table("AdhiSuchanaMaster")]
public partial class AdhiSuchanaMaster
{
    public string EmployeeName { get; set; } = null!;

    [Column(TypeName = "text")]
    public string Type { get; set; } = null!;

    [Column(TypeName = "text")]
    public string TypeName { get; set; } = null!;

    [Column(TypeName = "text")]
    public string Designation { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    [Column(TypeName = "text")]
    public string Class { get; set; } = null!;

    public DateOnly CompletionOfAgeofRetirement5860 { get; set; }

    public DateOnly RetirementDate { get; set; }

    public int SandarbhNumber { get; set; }

    public DateOnly SandarbhDate { get; set; }

    [Key]
    public int Id { get; set; }

    public bool IsActive { get; set; }

    [StringLength(10)]
    public string? CreatedBy { get; set; }

    [StringLength(10)]
    public string? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    public Guid UniqueId { get; set; }

    [StringLength(50)]
    public string LoginUser { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime EntryDate { get; set; }

    [StringLength(50)]
    public string Status { get; set; } = null!;

    [StringLength(200)]
    public string FinancialYear { get; set; } = null!;
}
