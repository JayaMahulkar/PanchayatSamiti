using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class DepartmentMaster
{
    public int Id { get; set; }

    public string? DepartmentName { get; set; }

    public bool? IsActive { get; set; }

    public string? Createdby { get; set; }

    public string? UpdatedBy { get; set; }

    public Guid UniqueId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
