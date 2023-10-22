using Athletes.Info.Request;
using Athletes.Info.Request.EditRequests;
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
        void EditAthletesPassword(AthleteEditPasswordRequest athleteEditPasswordRequest);
        void EditAthletesUsernameAndEmail(AthleteEditUsernameAndEmailRequest editUsernameAndEmailRequest);
        void EditAthletesFavoriteActivity(AthleteEditFavoriteActivityRequest editFavoriteActivityRequest);
        void EditAthletesLocation(AthleteEditLocationRequest athleteEditLocationRequest);
    }
}
