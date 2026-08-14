namespace PanchayatSamitiAPI.Model
{
    public class RelationModel
    {
        public int Id { get; set; }

        public string? Relation { get; set; }

        public bool? IsActive { get; set; }

        public Guid UniqueId { get; set; }
    }
}
