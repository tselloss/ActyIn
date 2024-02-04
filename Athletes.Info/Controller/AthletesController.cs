using Athletes.Info.Interface;
using Athletes.Info.Model;
using Athletes.Info.Repository;
using Athletes.Info.Request.EditRequests;
using AutoMapper;
using Define.Common.Exceptions;
using Define.Common.Extension.Routes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Postgres.Context.Entities;

namespace Athletes.Info.Controller;
[Route(ActionNames.Controller)]
[ApiController]
public class AthletesController : ControllerBase
{
    private readonly IAthletes _athletesInfo;
    private readonly ILogger<AthletesController> _logger;
    private readonly IMapper _mapper;
    private readonly AthleteInfoService _athleteInfoService;

    public AthletesController(IAthletes athleteInfo, ILogger<AthletesController> logger, IMapper mapper, AthleteInfoService athletesInfoService)
    {
        _logger = logger ?? throw new ArgumentException(nameof(logger));
        _athletesInfo = athleteInfo ?? throw new ArgumentException(nameof(athleteInfo));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _athleteInfoService = athletesInfoService ?? throw new ArgumentNullException(nameof(athletesInfoService));
    }

    [Authorize]
    [HttpGet(ActionNames.GetAllUsers)]
    public async Task<ActionResult<IEnumerable<AthleteInfoDTO>>> GetAllUsersAsync()
    {
        var users = await _athletesInfo.GetAllAthletesAsync();
        if (users == null)
        {
            _logger.LogInformation(AthletesExceptionMessages.UndefinedUsers);
            return NoContent();
        }
        return Ok(_mapper.Map<IEnumerable<AthleteInfoDTO>>(users));
    }

    [Authorize]
    [HttpGet(ActionNames.GetUserById)]
    public async Task<ActionResult<AthleteInfoDTO>> GetUserInfoByIdAsync(int id)
    {
        var user = await _athletesInfo.GetAthletesInfoByIdAsync(id);
        if (user == null)
        {
            _logger.LogInformation(AthletesExceptionMessages.UndefinedUserId + $"{id}");
            return NoContent();
        }
        var getUser = _mapper.Map<AthleteInfoDTO>(user);
        return Ok(getUser);
    }

    //[Authorize]
    [HttpGet(ActionNames.GetUserByUsername)]
    public async Task<ActionResult<AthleteInfoDTO>> GetUserInfoByUsernameAsync(string username, CancellationToken none)
    {
        var user = await _athletesInfo.GetAthletesInfoByUsernameAsync(username);
        if (user == null)
        {
            _logger.LogInformation(AthletesExceptionMessages.UndefinedUserId + $"{username}");
            return NoContent();
        }
        var getUser = _mapper.Map<AthleteInfoDTO>(user);
        return Ok(getUser);
    }

    [HttpPut(ActionNames.EditAthleteInfo)]
    public IActionResult EditAthletesInfo(AthleteEditInfoRequest request)
    {
        var user = _athletesInfo.EditAthletesInfo(request);
        if (user == null)
        {
            _logger.LogInformation(AthletesExceptionMessages.UndefinedUserId + $"{request}");
            return NoContent();
        }
        return Ok();
    }

    [Authorize]
    [HttpDelete(ActionNames.DeleteUser)]
    public async Task<ActionResult> DeleteUser(int id)
    {
        var users = await _athletesInfo.GetAthletesInfoByIdAsync(id);

        if (users == null)
        {
            _logger.LogInformation(AthletesExceptionMessages.UndefinedUserId + $"{id}");
            return NoContent();
        }
        var newUser = _mapper.Map<AthletesEntity>(users);
        _athletesInfo.DeleteAthletesByIdAsync(newUser);

        await _athleteInfoService.SaveChangesAsync(AthletesExceptionMessages.AthleteCanNotDeleted);
        return Ok(users);
    }
}

