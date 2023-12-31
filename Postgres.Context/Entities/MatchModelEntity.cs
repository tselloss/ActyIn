using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Postgres.Context.Entities;

public record MatchModelEntity
{    
    [Key]
    [JsonIgnore]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MatchModelId { get; set; }

    [Required]
    public bool LikeThePotentialAthlete { get; set; }
}
