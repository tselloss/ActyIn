using Define.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Postgres.Context.Entities;

public record AthletesSecretCred
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AthletesId { get; set; }
    [JsonIgnore]
    [EmailAddress]
    public string Email { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
    [JsonIgnore]
    public string Address { get; set; }
    [JsonIgnore]
    public int PostalCode { get; set; }
    [JsonIgnore]
    public Roles Role { get; set; }
}
