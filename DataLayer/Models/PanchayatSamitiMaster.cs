using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class PanchayatSamitiMaster
{
    public int Id { get; set; }

    public string? PanchayatSamitiName { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public Guid UniqueId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }
}
