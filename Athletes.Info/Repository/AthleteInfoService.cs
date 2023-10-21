using Athletes.Info.Interface;
using Athletes.Info.Model;
using Athletes.Info.Request;
using Microsoft.AspNetCore.Mvc;
using Postgres.Context.DBContext;

namespace Athletes.Info.Repository
{
    public class AthleteInfoService : IAthletes
    {

        private readonly NpgsqlContext _context;

        public Task<IActionResult> DeleteAthletesByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> EditAthletes(AthletesEditRequest editRequest)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<IEnumerable<AthleteInfoDTO>>> GetAllAthletesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<AthleteInfoDTO>> GetAthletesInfoByIdAsync(int athleteId)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> LoginAthlete(AthletesLoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> RegisterAthlete(AthletesRegisterRequest registerRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
