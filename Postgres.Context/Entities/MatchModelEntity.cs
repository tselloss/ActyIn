using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Postgres.Context.Entities;

public record MatchModelEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MatchModelId { get; set; }

    [Required]
    public bool LikeThePotentialAthlete { get; set; }

    public int ChosenActivityId { get; set; }

    [Required]
    public IEnumerable<ChosenActivityEntity> ChosenActivities { get; set; }
    public BookingEntity BookingEntity { get; internal set; }
}
