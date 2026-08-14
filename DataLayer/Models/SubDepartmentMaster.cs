using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class SubDepartmentMaster
{
    public int Id { get; set; }

    public string SubDepartmentName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public Guid UniqueId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
