using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Athletes.Info.Model
{
    public record AthleteInfoBase
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]*$")]
        [MaxLength(10)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
