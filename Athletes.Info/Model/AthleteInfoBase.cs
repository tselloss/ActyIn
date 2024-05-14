using System.ComponentModel.DataAnnotations;

namespace Athletes.Info.Model;
public record AthleteInfoBase
{
    [Required]
    [MaxLength(15)]
    public string Username { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
