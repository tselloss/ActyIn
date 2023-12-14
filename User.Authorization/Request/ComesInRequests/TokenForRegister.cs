using Athletes.Info.Model;

namespace User.Authorization.Request.ComesInRequests;

public record TokenForRegister : AthleteInfoBase
{
    public string Token { get; set; } = null;
}
