using Athletes.Info.Request.ComesInRequests;
using Postgres.Context.Entities;

namespace Athletes.Info.Extension.Methods
{
    public class Mapper
    {
        public AthletesEntity ToRegisterAthlete(AthleteRegisterRequest athleteRegisterRequest)
        {
            return new AthletesEntity
            {
                Address = athleteRegisterRequest.Address,
                City = athleteRegisterRequest.City,
                Email = athleteRegisterRequest.Email,
                Password = athleteRegisterRequest.Password,
                PostalCode = athleteRegisterRequest.PostalCode,
                Role = athleteRegisterRequest.Role,
                Username = athleteRegisterRequest.Username,
            };
        }
    }
}
