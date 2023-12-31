using Athletes.Info.Model;
using System.ComponentModel.DataAnnotations;

namespace BookingModel.Info.Model;

public record BookingModelInfo
{
    [Required]
    public string UsernamePicker { get; set; }
    [Required]
    public string UsernameSelected { get; set; }
    [Required]
    public DateTime SelectedDate { get; set; }
    [Required]
    public string ActivityName { get; set; }
    [Required]
    public bool IsCanceled { get; set; }
}
