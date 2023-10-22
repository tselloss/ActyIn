using Athletes.Info.Request;
using Athletes.Info.Request.EditRequests;
using Microsoft.AspNetCore.Mvc;
using Postgres.Context.Entities;

namespace Athletes.Info.Interface
{
    public interface IAthletes
    {
        Task<IEnumerable<AthletesEntity>> GetAllAthletesAsync();
        Task<AthletesEntity> GetAthletesInfoByIdAsync(int athleteId);
        void RegisterAthlete(AthletesEntity registerRequest);
        void LoginAthlete(AthleteLoginRequest loginRequest);
        void DeleteAthletesByIdAsync(AthletesEntity athletesEntity);
        void EditAthletesPassword(AthleteEditRequest editRequest);
        void EditAthletesUsernameAndEmail(AthleteEditRequest editRequest);
        void EditAthletesFavoriteActivity(AthleteEditRequest editRequest);
        void EditAthletesLocation(AthleteEditRequest editRequest);
    }
}
