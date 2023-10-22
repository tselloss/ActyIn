using System.ComponentModel.DataAnnotations;

namespace Athletes.Info.Request.EditRequests
{
    internal class AthleteEditFavoriteActivityRequest
    {
        [Required]
        public string FavoriteActivity { get; set; }
    }
}
