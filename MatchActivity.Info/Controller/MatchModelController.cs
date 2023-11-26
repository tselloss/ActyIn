using Athletes.Info.Interface;
using AutoMapper;
using ChooseActivity.Info.Model;
using ChooseActivity.Info.Repository;
using Define.Common.Extension.Routes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Postgres.Context.Entities;

namespace MatchActivity.Info.Controller
{
    [Route(ActionNames.Controller)]
    [ApiController]
    public class MatchModelController : ControllerBase
    {
        private readonly IChooseActivity _chooseActivity;
        private readonly ILogger<MatchModelController> _logger;
        private readonly IMapper _mapper;
        private readonly ChosenActivityInfoService _chosenActivityInfoService;

        public MatchModelController(IChooseActivity chooseActivity, ILogger<MatchModelController> logger, IMapper mapper, ChosenActivityInfoService chosenActivityInfoService)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _chooseActivity = chooseActivity ?? throw new ArgumentException(nameof(chooseActivity));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _chosenActivityInfoService = chosenActivityInfoService ?? throw new ArgumentNullException(nameof(chosenActivityInfoService));
        }

        [HttpGet(ActionNames.GetAllChosenActivities)]
        public async Task<ActionResult<IEnumerable<ChooseActivityInfo>>> GetAllChosenActivitiesAsync()
        {
            var activities = await _chosenActivityInfoService.GetAllChosenActivityOfAthletesAsync();
            if (activities == null)
            {
                _logger.LogInformation("We have no activities on db");
                return NoContent();
            }
            return Ok(_mapper.Map<IEnumerable<ChosenActivityEntity>>(activities));
        }

        [HttpGet(ActionNames.GetUserById)]
        public async Task<ActionResult<ChooseActivityInfo>> GetUserInfoByIdAsync(int id)
        {
            var activitiesById = await _chosenActivityInfoService.GetChosenActivityOfAthletesInfoByIdAsync(id);
            if (activitiesById == null)
            {
                _logger.LogInformation("This is the chosen activity with id: " + $"{id}");
                return NoContent();
            }
            var getActivity = _mapper.Map<ChosenActivityEntity>(activitiesById);
            return Ok(getActivity);
        }

        [HttpDelete(ActionNames.DeleteUser)]
        public async Task<ActionResult> DeleteActivityUser(int id)
        {
            var getActivityById = await _chosenActivityInfoService.GetChosenActivityOfAthletesInfoByIdAsync(id);

            if (getActivityById == null)
            {
                _logger.LogInformation("We have not found this Activity with the id: " + $"{id}");
                return NoContent();
            }
            var newActivity = _mapper.Map<ChosenActivityEntity>(getActivityById);
            _chosenActivityInfoService.DeleteChosenActivityOfAthletesByIdAsync(newActivity);

            await _chosenActivityInfoService.SaveChangesAsync("We can not manage to delete the activity");
            return Ok(getActivityById);
        }

        [HttpPost(ActionNames.CreateNewActivity)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult RegisterUser([FromBody] ChooseActivityInfo chooseActivityInfo)
        {
            var mapper = _mapper.Map<ChosenActivityEntity>(chooseActivityInfo);
            var entity = _chosenActivityInfoService.CreateAnActivity(mapper);

            if (entity is BadRequestObjectResult badRequest)
            {
                return BadRequest(new { Error = badRequest.Value });
            }

            return Ok();
        }
    }
}

