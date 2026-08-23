using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PanchayatSamitiAPI.Model
{
    public class AdhiSuchanaFormModel
    {
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

        public bool? IsActive { get; set; }

        public Guid UniqueId { get; set; }

      

     

    }
}
