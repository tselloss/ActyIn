using Athletes.Info.Model;

namespace User.Authorization.Request.ComesInRequests;

public record TokenForLogin : AthleteInfoBase
{
    public string Token { get; set; } = null;
}
