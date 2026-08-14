namespace PanchayatSamitiAPI.Model
{
    public class DesignationModel
    {
        public int Id { get; set; }

        public string? Designation { get; set; }

        public bool? IsActive { get; set; }

        public Guid UniqueId { get; set; }
    }
}
