using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Postgres.Context.Entities;

public record ChosenActivityEntity
{
    [Key]
    [JsonIgnore]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ChosenActivityId { get; set; }

    [Required]
    public string Activity { get; set; }

    [Required]
    public DateTime DateTime { get; set; }

    [Required]
    public string Username { get; set; }
}
