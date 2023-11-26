using Define.Common.Exceptions;
using MatchActivity.Info.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Postgres.Context.DBContext;
using Postgres.Context.Entities;

namespace MatchActivity.Info.Repository
{
    public class MatchModelService : ControllerBase, IMatchModel
    {
        private readonly NpgsqlContext _context;

        public MatchModelService(NpgsqlContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void DeleteMatchModelOfAthleteByIdAsync(MatchModelEntity matchModel)
        {
            _context.MatchModels.Remove(matchModel);
        }

        public async Task<IEnumerable<MatchModelEntity>> GetAllMatchModelsOfAthletesAsync()
        {
            return await _context.MatchModels.OrderBy(_ => _.MatchModelId).ToListAsync();
        }

        public async Task<MatchModelEntity> GetMatchModelsOfAthletesInfoByIdAsync(int matchModelId)
        {
            return await _context.MatchModels.Where(_ => _.MatchModelId == matchModelId).FirstOrDefaultAsync();
        }

        public IActionResult SaveMatchModelOfUser(MatchModelEntity matchModel)
        {       
            _context.MatchModels.Add(matchModel);
            _context.SaveChanges();

            return Ok("The request succeed");
        }

        public async Task<bool> SaveChangesAsync(string message)
        {
            try
            {
                return await _context.SaveChangesAsync() >= 0;
            }
            catch (ControllerExceptionMessage)
            {
                throw new ControllerExceptionMessage(message);
            }
        }
    }
}
