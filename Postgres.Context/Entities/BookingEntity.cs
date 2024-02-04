using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Postgres.Context.Entities;

public record BookingEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BookingId { get; set; }
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

    public virtual MatchModelEntity MatchModel { get; set; }

    public virtual AthletesEntity Athletes { get; set; }
}
