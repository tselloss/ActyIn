using Athletes.Info.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Athletes.Info.Request.EditRequests;

public record AthleteEditLocationRequest : AthleteInfoBase
{
    [Required]
    public string Address { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public int PostalCode { get; set; }
}
