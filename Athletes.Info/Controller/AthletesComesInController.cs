using Athletes.Info.Interface;
using Athletes.Info.Model;
using Athletes.Info.Repository;
using Athletes.Info.Request;
using AutoMapper;
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

        [HttpPost("actyin/registerUser")]
        public ActionResult<AthleteInfo> RegisterUser([FromBody] AthletesRegisterRequest registerRequest)
        {
            var register = _mapper.Map<AthletesEntity>(registerRequest);
            _athleteInfoService.RegisterAthlete(register);

            return Ok();
        }

        [HttpPost("actyin/loginUser")]
        public ActionResult LoginUser([FromBody] AthletesLoginRequest loginRequest)
        {
            _athleteInfoService.LoginAthlete(loginRequest);

            return Ok();
        }

    }
}

