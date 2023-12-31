using Athletes.Info.Model;
using System.ComponentModel.DataAnnotations;

namespace ChooseActivity.Info.Model;

public record ChooseActivityInfo
{
    [Required]
    public string Activity { get; set; }

    [Required]
    public string DateTime { get; set; }

    [Required]
    public string Username { get; set; }
}
