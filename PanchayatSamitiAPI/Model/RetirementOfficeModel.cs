namespace PanchayatSamitiAPI.Model
{
    public class RetirementOfficeModel
    {
        public int Id { get; set; }

        public string? RetirementOffice { get; set; }

        public bool? IsActive { get; set; }

        public Guid UniqueId { get; set; }
    }
}
