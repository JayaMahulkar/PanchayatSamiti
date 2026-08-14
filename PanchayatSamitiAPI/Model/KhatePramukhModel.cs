namespace PanchayatSamitiAPI.Model
{
    public class KhatePramukhModel
    {
        public int Id { get; set; }

        public string? KhatePramukh { get; set; }

        public bool? IsActive { get; set; }

        public Guid UniqueId { get; set; }
    }
}
