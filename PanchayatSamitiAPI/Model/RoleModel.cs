namespace PanchayatSamitiAPI.Model
{
    public class RoleModel
    {
        public string? RoleId { get; set; }

        public string? Role { get; set; }

        public bool? IsActive { get; set; }

        public Guid UniqueId { get; set; }
    }
}
