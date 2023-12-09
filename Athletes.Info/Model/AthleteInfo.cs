using System.ComponentModel.DataAnnotations;

namespace Athletes.Info.Model;
public record AthleteInfo : AthleteInfoDTO
{
    [Required]
    [MaxLength(16)]
    public string Password { get; set; }
}

