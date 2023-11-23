using Define.Common;
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

        [Required]
        public AthletesEntity AthletesEntity { get; set; }
    }
}
