using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Models;

[Table("KaryalayaPramukh")]
public partial class KaryalayaPramukh
{
    [Key]
    public int Id { get; set; }

    public Guid UniqueId { get; set; }

    [Column("KaryalayaPramukh")]
    [StringLength(200)]
    public string KaryalayaPramukh1 { get; set; } = null!;

    public bool IsActive { get; set; }

    [StringLength(100)]
    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    [StringLength(100)]
    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
}
