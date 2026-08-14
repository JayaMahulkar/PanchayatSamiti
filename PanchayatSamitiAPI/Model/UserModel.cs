namespace PanchayatSamitiAPI.Model
{
    public class UserModel
    {
        public string? Id { get; set; }

        public string? Name { get; set; }

        public string? EmailId { get; set; }

        public string? Password { get; set; }

        public bool? IsActive { get; set; }

        public Guid UniqueId { get; set; }
    }
}
