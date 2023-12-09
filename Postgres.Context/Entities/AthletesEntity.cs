using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Postgres.Context.Entities;

public record AthletesEntity : AthletesSecretCred
{
    [MaxLength(50)]
    public string Username { get; set; }
    public string City { get; set; }
    public string FavoriteActivity { get; set; }
    [NotMapped]
    public IFormFile ProfileImage { get; set; }

    public ICollection<ChosenActivityEntity> ChosenActivities { get; set; }
}
