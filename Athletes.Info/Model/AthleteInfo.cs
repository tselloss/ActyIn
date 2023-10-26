using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Athletes.Info.Model
{
    public record AthleteInfo : AthleteInfoDTO
    {
        [Required]
        [MaxLength(16)]
        public string Password { get; set; }
    }
}
