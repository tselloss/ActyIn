using Athletes.Info.Model;
using Athletes.Info.Request;
using Microsoft.AspNetCore.Mvc;

namespace Athletes.Info.Interface
{
    public interface IAthletes
    {
        Task<ActionResult<IEnumerable<AthleteInfoDTO>>> GetAllAthletesAsync();
        Task<ActionResult<AthleteInfoDTO>> GetAthletesInfoByIdAsync(int athleteId);
        Task<IActionResult> RegisterAthlete(AthletesRegisterRequest registerRequest);
        Task<IActionResult> LoginAthlete(AthletesLoginRequest loginRequest);
        Task<IActionResult> DeleteAthletesByIdAsync(int id);
        Task<IActionResult> EditAthletes(AthletesEditRequest editRequest);
    }
}
