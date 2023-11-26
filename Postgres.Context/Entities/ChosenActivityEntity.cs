using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Postgres.Context.Entities
{
    public record ChosenActivityEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChosenActivityId { get; set; }

        [Required]
        public string ChosenActivityName { get; set; }

        // Foreign key property
        public int AthletesEntityId { get; set; }
        public AthletesEntity AthletesEntity { get; set; }

        // Foreign key property
        public int MatchModelId { get; set; }
        public MatchModelEntity MatchModel { get; set; }
    }
}
