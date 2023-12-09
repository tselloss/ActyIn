using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Postgres.Context.Entities;

public record BookingEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BookingId { get; set; }

    public int MatchModelId { get; set; }
    public MatchModelEntity MatchModel { get; set; }

    [Required]
    public bool IsCanceled { get; set; }
}
