using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postgres.Context.Entities
{
    public record MatchModelEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchModelId { get; set; }

        [Required]
        public bool LikeThePotentialAthlete { get; set; }

        [Required]
        public IEnumerable<ChosenActivityEntity> ChosenActivities { get; set; }
    }
}
