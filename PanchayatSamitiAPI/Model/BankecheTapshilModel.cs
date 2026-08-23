namespace PanchayatSamitiAPI.Model
{
    public class BankecheTapshilModel
    {
        public int Id { get; set; }

        public string? BankecheTapshil { get; set; }

        public bool? IsActive { get; set; }
        public string CreatedDate { get; set; } = "";

        public Guid UniqueId { get; set; }
    }
}
