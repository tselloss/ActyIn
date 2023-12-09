using Define.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Postgres.Context.Entities;

public record AthletesSecretCred
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AthletesId { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
    [MaxLength(50)]
    public string Address { get; set; }
    public int PostalCode { get; set; }
    public Roles Role { get; set; }
}
