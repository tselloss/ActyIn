using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Postgres.Context.Entities;

public class ApplicationFileEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SportId { get; set; }

    [Required]
    public string SportName { get; set; }

    [Required]
    public string FileName { get; set; }

    public string ContentType { get; set; }
}
