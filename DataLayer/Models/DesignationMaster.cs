using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class DesignationMaster
{
    public int Id { get; set; }

    public string Designation { get; set; } = null!;

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public Guid UniqueId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedBy { get; set; }
}
