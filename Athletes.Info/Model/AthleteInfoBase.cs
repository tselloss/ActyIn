using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Athletes.Info.Model
{
    public record AthleteInfoBase
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]*$")]
        [JsonPropertyName("userName")]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
