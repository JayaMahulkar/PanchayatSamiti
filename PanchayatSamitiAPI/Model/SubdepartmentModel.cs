using System.ComponentModel.DataAnnotations;

namespace PanchayatSamitiAPI.Model
{
    public class SubdepartmentModel
    {
        [Key]
        public int Id { get; set; }

        public string? SubDepartmentName { get; set; }

        public bool? IsActive { get; set; }

        public Guid UniqueId { get; set; }

    }
}
