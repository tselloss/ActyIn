using Athletes.Info.Request;
using Postgres.Context.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Athletes.Info.Extension.Methods
{
        public class ToLoginAnAthlete
        {
            public AthletesEntity ToLoginAthlete(AthletesLoginRequest athleteLoginRequest)
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
