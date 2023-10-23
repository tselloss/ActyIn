using Define.Common;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Athletes.Info.Model
{
    public record AthleteInfoDTO : AthleteInfoBase
    {
        [Required]
        [JsonPropertyName("userAddress")]
        public string Address { get; set; }
        [Required]
        [JsonPropertyName("userCity")]
        public string City { get; set; }
        [Required]
        [JsonPropertyName("userPostalCode")]
        public int PostalCode { get; set; }
        [Required]
        [JsonPropertyName("userFavoriteActivity")]
        public string FavoriteActivity { get; set; }
        [Required]
        [JsonPropertyName("actionRole")]
        public Roles Role { get; set; }
    }
}
