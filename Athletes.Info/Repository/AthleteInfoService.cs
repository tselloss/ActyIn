using Athletes.Info.Interface;
using Athletes.Info.Request.EditRequests;
using Castle.Core.Internal;
using Define.Common.Exceptions;
using Define.Common.Extension.Methods;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Postgres.Context.DBContext;
using Postgres.Context.Entities;


namespace Athletes.Info.Repository;

public class AthleteInfoService : ControllerBase, IAthletes
{

    private readonly NpgsqlContext _context;

    public AthleteInfoService(NpgsqlContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void DeleteAthletesByIdAsync(AthletesEntity athletesEntity)
    {
        _context.AthletesInfo.Remove(athletesEntity);
    }

    public IActionResult EditAthletesInfo(AthleteEditInfoRequest athleteEditInfoRequest)
    {
        var editInfo = _context.AthletesInfo.Where(_ => _.Username == athleteEditInfoRequest.Username).First();
        if (athleteEditInfoRequest.Password != null)
        {
            var hashedPass = PasswordHash.CreatePasswordHash(athleteEditInfoRequest.Password);
            editInfo.Password = hashedPass;
        }
        
        if (editInfo.FavoriteActivity != null)
        {
            editInfo.FavoriteActivity = athleteEditInfoRequest.FavoriteActivity;
        }
        if (editInfo.City != null)
        {
            editInfo.City = athleteEditInfoRequest.City;
        }
        if (editInfo.PostalCode != null)
        {
            editInfo.PostalCode = athleteEditInfoRequest.PostalCode;
        }

        _context.SaveChanges();

        return Ok(AthletesMessages.CompletedRequest);
    }

    public IActionResult EditAthletesFavoriteActivity(AthleteEditFavoriteActivityRequest editFavoriteActivityRequest)
    {
        if (editFavoriteActivityRequest.Email == null || editFavoriteActivityRequest.Username == null)
        {
            return BadRequest(AthletesExceptionMessages.UndefinedUserEmail);
        }
        if (_context.AthletesInfo.Any(u => u.Username == editFavoriteActivityRequest.Username))
        {
            return BadRequest(string.Format(AthletesExceptionMessages.AthleteHaveSameUsername, editFavoriteActivityRequest.Username));
        }

        if (_context.AthletesInfo.Any(u => u.Email == editFavoriteActivityRequest.Email))
        {
            return BadRequest(string.Format(AthletesExceptionMessages.UndefinedUserEmail, editFavoriteActivityRequest.Email));
        }

        var favAct = _context.AthletesInfo.Where(_ => _.FavoriteActivity == editFavoriteActivityRequest.FavoriteActivity).First();
        if (favAct != null)
            favAct.FavoriteActivity = editFavoriteActivityRequest.FavoriteActivity;

        _context.SaveChanges();

        return Ok(AthletesMessages.CompletedRequest);
    }

    public IActionResult EditAthletesLocation(AthleteEditLocationRequest athleteEditLocationRequest)
    {
        if (athleteEditLocationRequest.Email == null || athleteEditLocationRequest.Username == null)
        {
            return BadRequest(AthletesExceptionMessages.UndefinedUserEmail);
        }

        if (_context.AthletesInfo.Any(u => u.Username == athleteEditLocationRequest.Username))
        {
            return BadRequest(string.Format(AthletesExceptionMessages.AthleteHaveSameUsername, athleteEditLocationRequest.Username));
        }

        if (_context.AthletesInfo.Any(u => u.Email == athleteEditLocationRequest.Email))
        {
            return BadRequest(string.Format(AthletesExceptionMessages.UndefinedUserEmail, athleteEditLocationRequest.Email));
        }

        var editLocation = _context.AthletesInfo.Where(_ => _.Username == athleteEditLocationRequest.Username).First();
        if (editLocation != null)
        {
            editLocation.Address = athleteEditLocationRequest.Address;
            editLocation.PostalCode = athleteEditLocationRequest.PostalCode;
            editLocation.City = athleteEditLocationRequest.City;
        }

        _context.SaveChanges();

        return Ok(AthletesMessages.CompletedRequest);
    }

    public IActionResult EditAthletesPassword(AthleteEditPasswordRequest athleteEditPasswordRequest)
    {
        if (athleteEditPasswordRequest.Email == null || athleteEditPasswordRequest.Username == null)
        {
            return BadRequest(AthletesExceptionMessages.UndefinedUserEmail);
        }

        if (_context.AthletesInfo.Any(u => u.Username == athleteEditPasswordRequest.Username))
        {
            return BadRequest(string.Format(AthletesExceptionMessages.AthleteHaveSameUsername, athleteEditPasswordRequest.Username));
        }

        if (_context.AthletesInfo.Any(u => u.Email == athleteEditPasswordRequest.Email))
        {
            return BadRequest(string.Format(AthletesExceptionMessages.UndefinedUserEmail, athleteEditPasswordRequest.Email));
        }

        var editPassword = _context.AthletesInfo.Where(_ => _.Username == athleteEditPasswordRequest.Username).First();
        if (editPassword != null)
        {
            editPassword.Password = athleteEditPasswordRequest.Password;
        }

        _context.SaveChanges();

        return Ok(AthletesMessages.CompletedRequest);
    }

    public IActionResult EditAthletesEmail(AthleteEditUsernameAndEmailRequest editUsernameAndEmailRequest)
    {
        if (editUsernameAndEmailRequest.Email == null || editUsernameAndEmailRequest.Username == null)
        {
            return BadRequest(AthletesExceptionMessages.UndefinedUserEmail);
        }

        if (_context.AthletesInfo.Any(u => u.Username == editUsernameAndEmailRequest.Username))
        {
            return BadRequest(string.Format(AthletesExceptionMessages.AthleteHaveSameUsername, editUsernameAndEmailRequest.Username));
        }

        if (_context.AthletesInfo.Any(u => u.Email == editUsernameAndEmailRequest.Email))
        {
            return BadRequest(string.Format(AthletesExceptionMessages.UndefinedUserEmail, editUsernameAndEmailRequest.Email));
        }

        var editEmail = _context.AthletesInfo.Where(_ => _.Username == editUsernameAndEmailRequest.Username).First();
        if (editEmail != null)
        {
            editEmail.Email = editUsernameAndEmailRequest.Email;
        }

        _context.SaveChanges();

        return Ok(AthletesMessages.CompletedRequest);
    }

    public async Task<IEnumerable<AthletesEntity>> GetAllAthletesAsync()
    {
        return await _context.AthletesInfo.OrderBy(_ => _.AthletesId).ToListAsync();
    }

    public async Task<AthletesEntity> GetAthletesInfoByIdAsync(int athleteId)
    {
        return await _context.AthletesInfo.Where(_ => _.AthletesId == athleteId).FirstOrDefaultAsync();
    }

    public IActionResult RegisterAthlete(AthletesEntity registerRequest)
    {

        if (registerRequest.Email == null || registerRequest.Username == null)
        {
            return BadRequest(AthletesExceptionMessages.UndefinedUserEmail);
        }

        if (_context.AthletesInfo.Any(u => u.Username == registerRequest.Username))
        {
            return BadRequest(string.Format(AthletesExceptionMessages.AthleteHaveSameUsername, registerRequest.Username));
        }

        if (_context.AthletesInfo.Any(u => u.Email == registerRequest.Email))
        {
            return BadRequest(string.Format(AthletesExceptionMessages.UndefinedUserEmail, registerRequest.Email));
        }

        var hashedPass = PasswordHash.CreatePasswordHash(registerRequest.Password);
        registerRequest.Password = hashedPass;
        _context.AthletesInfo.Add(registerRequest);
        _context.SaveChanges();

        return Ok(AthletesMessages.CompletedRequest);
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

    public async Task<AthletesEntity> GetAthletesInfoByUsernameAsync(string username)
    {
        var user = await _context.AthletesInfo.Where(_ => _.Username == username).FirstOrDefaultAsync();
        return user;
    }
}
