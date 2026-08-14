namespace PanchayatSamitiAPI.Model
{
    public class BankModel
    {
        public int Id { get; set; }

        public string? BankName { get; set; }

        public bool? IsActive { get; set; }

        public Guid UniqueId { get; set; }
    }
}
