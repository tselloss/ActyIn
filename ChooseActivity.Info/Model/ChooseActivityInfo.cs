using Athletes.Info.Model;
using System.ComponentModel.DataAnnotations;

namespace ChooseActivity.Info.Model;

public record ChooseActivityInfo
{
    [Required]
    public string Activity { get; set; }

    [Required]
    public DateTime DateTime { get; set; }

    [Required]
    public AthleteInfoDTO athleteInfoDTO { get; set; }
}
