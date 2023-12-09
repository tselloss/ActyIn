using Athletes.Info.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace User.Authorization.Request.ComesInRequests;

public record AthleteLoginRequest : AthleteInfoBase
{
    [Required]
    [MaxLength(16)]
    [JsonPropertyName("password")]
    public string Password { get; set; }
}
