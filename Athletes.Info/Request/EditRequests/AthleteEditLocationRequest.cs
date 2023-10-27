using Athletes.Info.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Athletes.Info.Request.EditRequests
{
    public record AthleteEditLocationRequest 
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
    }
}
