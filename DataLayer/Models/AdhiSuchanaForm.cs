using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models;

[Table("AdhiSuchanaForm")]
public partial class AdhiSuchanaForm
{
    [Key]
    public int Id { get; set; }

    public string? EmployeeName { get; set; }

    public int? TypeId { get; set; }

    public int? PanchayatSamitiId { get; set; }

    public int? DesignationId { get; set; }

    public int? ClassId { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public DateOnly? DateforCompletion { get; set; }

    public DateOnly? DateOfRetirement { get; set; }

    [StringLength(50)]
    public string? ReferenceNumber { get; set; }

    public DateOnly? ReferenceDate { get; set; }

    public bool IsActive { get; set; }

    public Guid UniqueId { get; set; }

    [StringLength(10)]
    public string CreatedBy { get; set; } = null!;

    [StringLength(10)]
    public string UpdatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UpdatedDate { get; set; }
}
