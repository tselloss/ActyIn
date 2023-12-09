using MatchActivity.Info.Model;
using System.ComponentModel.DataAnnotations;

namespace BookingModel.Info.Model;

public record BookingModelInfo
{
    [Required]
    public MatchModelInfo matchModelInfo { get; set; }

    [Required]
    public bool IsCancelled { get; set; }
}
