using System.ComponentModel.DataAnnotations;

namespace Athletes.Info.Model
{
    public record AthleteInfo : AthleteInfoDTO
    {
        [Required]
        public string Password { get; set; }
    }
}
