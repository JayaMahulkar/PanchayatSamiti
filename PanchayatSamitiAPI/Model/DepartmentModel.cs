using System.ComponentModel;

namespace PanchayatSamitiAPI.Model
{
    public class DepartmentModel
    {
        public int Id { get; set; }

        public string? DepartmentName { get; set; }

        public bool? IsActive { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public Guid UniqueId { get; set; } = new Guid();

    }
}
