namespace PanchayatSamitiAPI.Model
{
    public class DepartmentModel
    {
        
        public int Id { get; set; }

        public string? DepartmentName { get; set; }

        public bool? IsActive { get; set; }

        public Guid UniqueId { get; set; }

    }
}
