using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Athletes.Info.Request.EditRequests
{
    public class AthleteEditFavoriteActivityRequest
    {
        [Required]
        [JsonPropertyName("userFavoriteActivity")]
        public string FavoriteActivity { get; set; }
    }
}
