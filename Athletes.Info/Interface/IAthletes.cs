using Athletes.Info.Request.EditRequests;
using Microsoft.AspNetCore.Mvc;
using Postgres.Context.Entities;
using System.Web.Mvc;

namespace Athletes.Info.Interface
{
    public interface IAthletes
    {
        Task<IEnumerable<AthletesEntity>> GetAllAthletesAsync();
        Task<AthletesEntity> GetAthletesInfoByIdAsync(int athleteId);
        AthletesEntity RegisterAthlete(AthletesEntity registerRequest);
        void DeleteAthletesByIdAsync(AthletesEntity athletesEntity);
        IActionResult EditAthletesPassword(AthleteEditPasswordRequest athleteEditPasswordRequest);
        IActionResult EditAthletesEmail(AthleteEditUsernameAndEmailRequest editUsernameAndEmailRequest);
        IActionResult EditAthletesFavoriteActivity(AthleteEditFavoriteActivityRequest editFavoriteActivityRequest);
        IActionResult EditAthletesLocation(AthleteEditLocationRequest athleteEditLocationRequest);
    }
}
