using AutoMapper;
using Define.Common.Extension.Routes;
using MatchActivity.Info.Interface;
using MatchActivity.Info.Model;
using MatchActivity.Info.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Postgres.Context.Entities;

namespace MatchActivity.Info.Controller;

[Route(ActionNames.Controller)]
[ApiController]
public class MatchModelController : ControllerBase
{
    private readonly IMatchModel _matchModel;
    private readonly ILogger<MatchModelController> _logger;
    private readonly IMapper _mapper;
    private readonly MatchModelService _matchModelInfoService;

    public MatchModelController(IMatchModel matchModel, ILogger<MatchModelController> logger, IMapper mapper, MatchModelService matchModelService)
    {
        _logger = logger ?? throw new ArgumentException(nameof(logger));
        _matchModel = matchModel ?? throw new ArgumentException(nameof(matchModel));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _matchModelInfoService = matchModelService ?? throw new ArgumentNullException(nameof(matchModelService));
    }

    [HttpGet(ActionNames.GetAllMatchModel)]
    public async Task<ActionResult<IEnumerable<MatchModelInfo>>> GetAllChosenActivitiesAsync()
    {
        var matchModel = await _matchModel.GetAllMatchModelsOfAthletesAsync();
        if (matchModel == null)
        {
            _logger.LogInformation("We have no activities on db");
            return NoContent();
        }
        return Ok(_mapper.Map<IEnumerable<MatchModelEntity>>(matchModel));
    }

    [HttpGet(ActionNames.GetMatchModelById)]
    public async Task<ActionResult<MatchModelInfo>> GetMatchModelInfoByIdAsync(int id)
    {
        var matchModelById = await _matchModel.GetMatchModelsOfAthletesInfoByIdAsync(id);
        if (matchModelById == null)
        {
            _logger.LogInformation("This is the chosen activity with id: " + $"{id}");
            return NoContent();
        }
        var getMatchModel = _mapper.Map<ChosenActivityEntity>(matchModelById);
        return Ok(getMatchModel);
    }

    [HttpDelete(ActionNames.DeleteMatchModel)]
    public async Task<ActionResult> DeleteMatchModel(int id)
    {
        var getMatchModelById = await _matchModel.GetMatchModelsOfAthletesInfoByIdAsync(id);

        if (getMatchModelById == null)
        {
            _logger.LogInformation("We have not found this Activity with the id: " + $"{id}");
            return NoContent();
        }
        var newActivity = _mapper.Map<MatchModelEntity>(getMatchModelById);
        _matchModel.DeleteMatchModelOfAthleteByIdAsync(newActivity);

        await _matchModelInfoService.SaveChangesAsync("We can not manage to delete the activity");
        return Ok(getMatchModelById);
    }

    [HttpPost(ActionNames.SaveMatchModel)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult SaveMatchModel([FromBody] MatchModelInfo matchModelInfo)
    {
        var mapper = _mapper.Map<MatchModelEntity>(matchModelInfo);
        var entity = _matchModel.SaveMatchModelOfUser(mapper);

        if (entity is BadRequestObjectResult badRequest)
        {
            return BadRequest(new { Error = badRequest.Value });
        }

        return Ok();
    }
}

