using Athletes.Info.Request.ComesInRequests;
using Postgres.Context.Entities;

namespace Athletes.Info.Extension.Methods
{
    public class ToLoginAnAthlete
    {
        public AthletesEntity ToLoginAthlete(AthleteLoginRequest athleteLoginRequest)
        {
            return new AthletesEntity
            {
                Email = athleteLoginRequest.Email,
                Password = athleteLoginRequest.Password,
                Username = athleteLoginRequest.Username,
            };
        }
    }
}
