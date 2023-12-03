using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Postgres.Context.Entities
{
    public class FileEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AthleteId { get; set; }

        [Required]
        public string AthleteName { get; set;}

        [Required]
        public string FileName { get; set; }

        public string ContentType { get; set; }
    }
}
