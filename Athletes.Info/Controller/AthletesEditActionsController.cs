using Athletes.Info.Interface;
using Athletes.Info.Model;
using Athletes.Info.Repository;
using Athletes.Info.Request.EditRequests;
using AutoMapper;
using Define.Common.Extension.Routes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Postgres.Context.Entities;

namespace Athletes.Info.Controller
{
    [Route(Actions.Controller)]
    [ApiController]
    public class AthletesEditActionsController : ControllerBase
    {
        private readonly IAthletes _athletesInfo;
        private readonly ILogger<AthletesController> _logger;
        private readonly IMapper _mapper;
        private readonly AthleteInfoService _athleteInfoService;

        public AthletesEditActionsController(IAthletes athleteInfo, ILogger<AthletesController> logger, IMapper mapper, AthleteInfoService athletesInfoService)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _athletesInfo = athleteInfo ?? throw new ArgumentException(nameof(athleteInfo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _athleteInfoService = athletesInfoService ?? throw new ArgumentNullException(nameof(athletesInfoService));
        }

        [HttpPost(Actions.EditFavoriteActivity)]
        public ActionResult<AthleteInfo> EditFavoriteActivity([FromBody] AthleteEditFavoriteActivityRequest athleteEditFavoriteActivityRequest)
        {
            var register = _mapper.Map<AthleteEditFavoriteActivityRequest>(athleteEditFavoriteActivityRequest);
            _athleteInfoService.EditAthletesFavoriteActivity(register);

            return Ok();
        }

        [HttpPost(Actions.EditAthleteLocation)]
        public ActionResult<AthleteInfo> EditAthleteLocation([FromBody] AthleteEditLocationRequest athleteEditLocationRequest)
        {
            var register = _mapper.Map<AthleteEditLocationRequest>(athleteEditLocationRequest);
            _athleteInfoService.EditAthletesLocation(register);

            return Ok();
        }

        [HttpPost(Actions.EditAthletePassword)]
        public ActionResult<AthleteInfo> EditAthletePassword([FromBody] AthleteEditPasswordRequest athleteEditPasswordRequest)
        {
            var register = _mapper.Map<AthleteEditPasswordRequest>(athleteEditPasswordRequest);
            _athleteInfoService.EditAthletesPassword(register);

            return Ok();
        }

        [HttpPost(Actions.EditAthleteUsernameAndEmailRequest)]
        public ActionResult<AthleteInfo> EditUsernameAndEmailRequest([FromBody] AthleteEditUsernameAndEmailRequest editUsernameAndEmailRequest)
        {
            var register = _mapper.Map<AthleteEditUsernameAndEmailRequest>(editUsernameAndEmailRequest);
            _athleteInfoService.EditAthletesUsernameAndEmail(register);

            return Ok();
        }
    }
}

