using Athletes.Info.Request;
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
        void EditAthletesPassword(AthletesEntity editRequest);
        void EditAthletesUsernameAndEmail(AthletesEntity editRequest);
        void EditAthletesFavoriteActivity(AthletesEntity editRequest);
        void EditAthletesLocation(AthletesEntity editRequest);
    }
}
