using System.ComponentModel.DataAnnotations;

namespace PanchayatSamitiAPI.Model
{
    public class VetanShreneeModel
    {
        [Key]
        public int Id { get; set; }

        public string? VetanShrenee { get; set; }

        public bool? IsActive { get; set; }

        public Guid UniqueId { get; set; }
    }
}
