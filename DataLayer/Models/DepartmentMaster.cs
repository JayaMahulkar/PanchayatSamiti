using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Models;

[Table("DepartmentMaster")]
public partial class DepartmentMaster
{
    [Key]
    public int Id { get; set; }

    public string? DepartmentName { get; set; }

    public bool IsActive { get; set; }

    [StringLength(10)]
    public string? Createdby { get; set; }

    [StringLength(10)]
    public string? UpdatedBy { get; set; }

    public Guid UniqueId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
