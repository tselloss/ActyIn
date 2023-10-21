using Athletes.Info.Request;
using Microsoft.AspNetCore.Mvc;
using Postgres.Context.Entities;

namespace Athletes.Info.Interface
{
    public interface IAthletes
    {
        Task<ActionResult<IEnumerable<AthletesEntity>>> GetAllAthletesAsync();
        Task<ActionResult<AthletesEntity>> GetAthletesInfoByIdAsync(int athleteId);
        void RegisterAthlete(AthletesEntity registerRequest);
        void LoginAthlete(AthletesLoginRequest loginRequest);
        void DeleteAthletesByIdAsync(AthletesEntity athletesEntity);
        void EditAthletes(AthletesEditRequest editRequest);
    }
}
