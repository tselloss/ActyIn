using Athletes.Info.Interface;
using Castle.Core.Internal;
using Define.Common.Exceptions;
using Define.Common.Extension.Methods;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Postgres.Context.DBContext;
using Postgres.Context.Entities;

namespace ChooseActivity.Info.Repository
{
    public class ChosenActivityInfoService : ControllerBase, IChooseActivity
    {
        private readonly NpgsqlContext _context;

        public ChosenActivityInfoService(NpgsqlContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void DeleteChosenActivityOfAthletesByIdAsync(ChosenActivityEntity chosenActivityEntity)
        {
            _context.ChooseActivityInfo.Remove(chosenActivityEntity);
        }

        public async Task<IEnumerable<ChosenActivityEntity>> GetAllChosenActivityOfAthletesAsync()
        {
            return await _context.ChooseActivityInfo.OrderBy(_ => _.ChosenActivityId).ToListAsync();

        }

        public async Task<ChosenActivityEntity> GetChosenActivityOfAthletesInfoByIdAsync(int chosenActivityId)
        {
            return await _context.ChooseActivityInfo.Where(_ => _.ChosenActivityId == chosenActivityId).FirstOrDefaultAsync();
        }

        public IActionResult CreateAnActivity(ChosenActivityEntity chosenActivityEntityRequest)
        {
            if (chosenActivityEntityRequest.ChosenActivityName.IsNullOrEmpty())
            {
                return BadRequest("The request has not any Activity");
            }

            _context.ChooseActivityInfo.Add(chosenActivityEntityRequest);
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
