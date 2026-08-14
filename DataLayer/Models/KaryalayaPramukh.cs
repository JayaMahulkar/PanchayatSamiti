using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class KaryalayaPramukh
{
    public int Id { get; set; }

    public Guid UniqueId { get; set; }

    public string KaryalayaPramukh1 { get; set; } = null!;

    public bool IsActive { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool IsDeleted { get; set; }
}
