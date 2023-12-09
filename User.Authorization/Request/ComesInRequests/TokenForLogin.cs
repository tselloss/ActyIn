namespace User.Authorization.Request.ComesInRequests;

public record TokenForLogin : AthleteLoginRequest
{
    public string Token { get; set; } = null;
}
