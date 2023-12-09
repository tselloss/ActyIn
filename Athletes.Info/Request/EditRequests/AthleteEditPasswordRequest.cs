using Athletes.Info.Model;
using System.ComponentModel.DataAnnotations;

namespace Athletes.Info.Request.EditRequests;

public record AthleteEditPasswordRequest : AthleteInfoBase
{
    [Required]
    [MaxLength(16)]
    public string Password { get; set; }
}
