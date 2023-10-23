using Athletes.Info.Interface;
using Athletes.Info.Model;
using Athletes.Info.Repository;
using Athletes.Info.Request.ComesInRequests;
using AutoMapper;
using Define.Common.Extension.Routes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Postgres.Context.Entities;

namespace Athletes.Info.Controller
{
    [Route("actyin/[controller]")]
    [ApiController]
    public class AthletesComesInController : ControllerBase
    {
        private readonly IAthletes _athletesInfo;
        private readonly ILogger<AthletesController> _logger;
        private readonly IMapper _mapper;
        private readonly AthleteInfoService _athleteInfoService;

        public AthletesComesInController(IAthletes athleteInfo, ILogger<AthletesController> logger, IMapper mapper, AthleteInfoService athletesInfoService)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _athletesInfo = athleteInfo ?? throw new ArgumentException(nameof(athleteInfo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _athleteInfoService = athletesInfoService ?? throw new ArgumentNullException(nameof(athletesInfoService));
        }
        /// <summary>
        /// Register a user on our DB, access to our API functions
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>

        [HttpPost(ActionNames.RegisterUser)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<AthleteInfo> RegisterUser([FromBody] AthleteRegisterRequest registerRequest)
        {
            var register = _mapper.Map<AthletesEntity>(registerRequest);
            _athleteInfoService.RegisterAthlete(register);

            return Ok();
        }

        /// <summary>
        /// User Login to our API functions
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        [HttpPost(ActionNames.LoginUser)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult LoginUser([FromBody] AthleteLoginRequest loginRequest)
        {
            _athleteInfoService.LoginAthlete(loginRequest);

            return Ok();
        }

    }
}

