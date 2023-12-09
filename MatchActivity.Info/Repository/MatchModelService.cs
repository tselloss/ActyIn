using Define.Common.Exceptions;
using MatchActivity.Info.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Postgres.Context.DBContext;
using Postgres.Context.Entities;

namespace MatchActivity.Info.Repository;
public class MatchModelService : ControllerBase, IMatchModel
{
    private readonly NpgsqlContext _context;
    private readonly ILogger<MatchModelService> _logger;

    public MatchModelService(NpgsqlContext context, ILogger logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = (ILogger<MatchModelService>)(logger ?? throw new ArgumentNullException(nameof(_logger)));
    }
    public void DeleteMatchModelOfAthleteByIdAsync(MatchModelEntity matchModel)
    {
        _context.MatchModels.Remove(matchModel);
        _logger.LogInformation(MatchModelLoggerMessages.DeleteException);
    }

    public async Task<IEnumerable<MatchModelEntity>> GetAllMatchModelsOfAthletesAsync()
    {

        try
        {
            var getAll = await _context.MatchModels.OrderBy(_ => _.MatchModelId).ToListAsync();
            _logger.LogInformation(MatchModelLoggerMessages.GetAllMatchModelSuccess);
            return getAll;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, MatchModelLoggerMessages.GetAllMatchModelException);
            throw;
        }
    }

    public async Task<MatchModelEntity> GetMatchModelsOfAthletesInfoByIdAsync(int matchModelId)
    {
        try
        {
            var getById = await _context.MatchModels.Where(_ => _.MatchModelId == matchModelId).FirstOrDefaultAsync();
            _logger.LogInformation(MatchModelLoggerMessages.GetByIdMatchModelException);
            return getById;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, MatchModelLoggerMessages.GetByIdMatchModelSuccess);
            throw;
        }
    }

    public IActionResult SaveMatchModelOfUser(MatchModelEntity matchModel)
    {
        try
        {
            _context.MatchModels.Add(matchModel);
            _context.SaveChanges();
            _logger.LogInformation(MatchModelLoggerMessages.SaveMatchModelException);

            return Ok(MatchModelLoggerMessages.SaveMatchModelSuccess);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, MatchModelLoggerMessages.SaveMatchModelException);
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
