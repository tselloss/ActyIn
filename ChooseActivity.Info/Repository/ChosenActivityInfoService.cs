using AutoMapper;
using Castle.Core.Internal;
using ChooseActivity.Info.Interface;
using ChooseActivity.Info.Model;
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
    private readonly IMapper _mapper;

    public ChosenActivityInfoService(NpgsqlContext context, ILogger logger, IMapper mapper)
    {
        //_logger = (ILogger<ChosenActivityInfoService>)(logger ?? throw new ArgumentException(nameof(logger)));
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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

    //TODO Create the chooseActivityInfo return correct things
    public async Task<IEnumerable<ChooseActivityInfo>> GetAllChosenActivityOfAthletesAsync()
    {
        try
        {            
            var getAll = await _context.ChooseActivityInfo.OrderBy(_ => _.ChosenActivityId).ToListAsync();
            var mapper = _mapper.Map<List<ChooseActivityInfo>>(getAll);
            return mapper;
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

    public IActionResult CreateAnActivity([FromBody] ChooseActivityInfo chosenActivityEntityRequest)
    {
        try
        {   
            var mapper = _mapper.Map<ChosenActivityEntity>(chosenActivityEntityRequest);
            if (chosenActivityEntityRequest.Activity.IsNullOrEmpty())
            {
                return BadRequest(ChosenActivityLoggerMessages.EmptyChosenActivityRequest);
            }
            _context.ChooseActivityInfo.Add(mapper);
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
