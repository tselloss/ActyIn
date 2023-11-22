using MatchActivity.Info.Model;
using System.ComponentModel.DataAnnotations;

namespace BookingModel.Info.Model
{
    public record BookingModelInfo
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public MatchModelInfo matchModelInfo { get; set; }

        [Required]
        public bool IsCancelled { get; set; }
    }
}
