using Athletes.Info.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Athletes.Info.Request.EditRequests
{
    public record AthleteEditFavoriteActivityRequest 
    {
        [Required]
        [JsonPropertyName("userFavoriteActivity")]
        public string FavoriteActivity { get; set; }
    }
}
