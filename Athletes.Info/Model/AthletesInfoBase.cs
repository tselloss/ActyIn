using System.ComponentModel.DataAnnotations;

namespace Athletes.Info.Model
{
    public record AthletesInfoBase
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
