using Athletes.Info.Request;
using Postgres.Context.Entities;
using System.Security.Cryptography;
using System.Text;

namespace Athletes.Info.Extension.Methods
{
        public class Mapper
        {
            public AthletesEntity ToRegisterAthlete(AthletesRegisterRequest athleteRegisterRequest)
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
