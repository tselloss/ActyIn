using System.ComponentModel.DataAnnotations;

namespace Athletes.Info.Request.EditRequests
{
    public class AthleteEditFavoriteActivityRequest
    {
        [Required]
        public string FavoriteActivity { get; set; }
    }
}
