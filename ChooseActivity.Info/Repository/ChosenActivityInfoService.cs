using Castle.Core.Internal;
using ChooseActivity.Info.Interface;
using Define.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Postgres.Context.DBContext;
using Postgres.Context.Entities;

namespace ChooseActivity.Info.Repository;

public class ChosenActivityInfoService : ControllerBase, IChooseActivity 
{
    private readonly NpgsqlContext _context;

    public ChosenActivityInfoService(NpgsqlContext context, ILogger logger)
    {
        //_logger = (ILogger<ChosenActivityInfoService>)(logger ?? throw new ArgumentException(nameof(logger)));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void DeleteChosenActivityOfAthletesByIdAsync(ChosenActivityEntity chosenActivityEntity)
    {
        try
        {
            _context.ChooseActivityInfo.Remove(chosenActivityEntity);
            //_logger.LogInformation(ChosenActivityLoggerMessages.SuccessRemoveChosenActivity);
        }
        catch
        {
            //_logger.LogInformation(ChosenActivityLoggerMessages.RemoveException);
        }
    }

    public async Task<IEnumerable<ChosenActivityEntity>> GetAllChosenActivityOfAthletesAsync()
    {
        try
        {
            var getAll = await _context.ChooseActivityInfo.OrderBy(_ => _.ChosenActivityId).ToListAsync();
            return getAll;
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, ChosenActivityLoggerMessages.GetAllChosenActivityException);
            throw;
        }
    }

    public async Task<ChosenActivityEntity> GetChosenActivityOfAthletesInfoByIdAsync(int chosenActivityId)
    {
        try
        {
            return await _context.ChooseActivityInfo.Where(_ => _.ChosenActivityId == chosenActivityId).FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, ChosenActivityLoggerMessages.GetAllChosenActivityException);
            throw;
        }
    }

    public IActionResult CreateAnActivity(ChosenActivityEntity chosenActivityEntityRequest)
    {
        try
        {
            if (chosenActivityEntityRequest.ChosenActivityName.IsNullOrEmpty())
            {
                return BadRequest(ChosenActivityLoggerMessages.EmptyChosenActivityRequest);
            }

            _context.ChooseActivityInfo.Add(chosenActivityEntityRequest);
            _context.SaveChanges();

            return Ok(ChosenActivityLoggerMessages.SaveChosenActivityException);
        }
        catch (Exception ex)
        {
            //_logger.LogError(ex, ChosenActivityLoggerMessages.GetAllChosenActivityException);
            throw;
        }
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
