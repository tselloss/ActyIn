using AutoMapper;
using Castle.Core.Internal;
using ChooseActivity.Info.Interface;
using ChooseActivity.Info.Model;
using Define.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Postgres.Context.DBContext;
using Postgres.Context.Entities;

namespace ChooseActivity.Info.Repository;

public class ChosenActivityInfoService : ControllerBase, IChooseActivity
{
    private readonly NpgsqlContext _context;
    private readonly IMapper _mapper;

    public ChosenActivityInfoService(NpgsqlContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public void DeleteChosenActivityOfAthletesByIdAsync(ChosenActivityEntity chosenActivityEntity)
    {
        try
        {
            _context.ChooseActivityInfo.Remove(chosenActivityEntity);
        }
        catch
        {
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
            throw;
        }
    }

    public async Task<ChosenActivityEntity> GetChosenActivityOfAthletesInfoByIdAsync(int chosenActivityId)
    {
        try
        {
            var activitiesById = await _context.ChooseActivityInfo.Where(_ => _.ChosenActivityId == chosenActivityId).FirstOrDefaultAsync();

            var getActivity = _mapper.Map<ChosenActivityEntity>(activitiesById);

            return getActivity;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<List<ChooseActivityInfo>> GetChosenActivityOfAthletesInfoByDateAsync(string date, string activity)
    {
        try
        {
            if (DateTime.TryParse(date, out var parsedDate))
            {
                // Filter activities by date
                var activities = await _context.ChooseActivityInfo
                    .Where(_ => _.DateTime == parsedDate.Date && _.Activity == activity)
                    .ToListAsync();

                var getActivity = _mapper.Map<List<ChooseActivityInfo>>(activities);

                return getActivity;
            }
            else
            {
                // Handle invalid date format
                throw new ArgumentException("Invalid date format.");
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions
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
