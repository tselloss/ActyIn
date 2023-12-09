using Postgres.Context.Entities;
using User.Authorization.Request.ComesInRequests;

namespace User.Authorization.Interface;

public interface IAuthorizationToken
{
    TokenForRegister GenerateTokenForRegister(AthletesEntity registeredAthlete);

    TokenForLogin GenerateTokenForLogin(AthleteLoginRequest athleteLoginRequest);

    AthleteLoginRequest Login(AthletesEntity loginRequest);
}
