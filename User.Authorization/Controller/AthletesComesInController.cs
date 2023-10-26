using Athletes.Info.Interface;
using Athletes.Info.Repository;
using AutoMapper;
using Define.Common.Extension.Routes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Postgres.Context.Entities;
using User.Authorization.Interface;
using User.Authorization.Repository;
using User.Authorization.Request.ComesInRequests;

namespace User.Authorization.Controller
{
    [Route("actyin/[controller]")]
    [ApiController]
    public class AthletesComesInController : ControllerBase
    {
        private readonly IAthletes _athletesInfo;
        private readonly ILogger<AthletesComesInController> _logger;
        private readonly IMapper _mapper;
        private readonly AthleteInfoService _athleteInfoService;
        private readonly IAuthorizationToken _authorization;
        private readonly AuthorizationToken _authorizationToken;

        public AthletesComesInController(IAthletes athleteInfo, ILogger<AthletesComesInController> logger, IMapper mapper, AthleteInfoService athletesInfoService, IAuthorizationToken authorization, AuthorizationToken authorizationToken)
        {
            _logger = logger ?? throw new ArgumentException(nameof(logger));
            _athletesInfo = athleteInfo ?? throw new ArgumentException(nameof(athleteInfo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _athleteInfoService = athletesInfoService ?? throw new ArgumentNullException(nameof(athletesInfoService));
            _authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));
            _authorizationToken = authorizationToken;
        }

        /// <summary>
        /// Register a user on our DB, access to our API functions
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>

        [HttpPost(ActionNames.RegisterUser)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<TokenForRegister> RegisterUser([FromBody] AthleteRegisterRequest registerRequest)
        {
            var register = _mapper.Map<AthletesEntity>(registerRequest);
            var entity = _athleteInfoService.RegisterAthlete(register);

            // Generate JWT token for the registered athlete
            var token = _authorization.GenerateTokenForRegister(entity);

            return Ok(new { Token = token });
        }

        /// <summary>
        /// User Login to our API functions
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        [HttpPost(ActionNames.LoginUser)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<TokenForLogin> LoginUser([FromBody] AthleteLoginRequest loginRequest)
        {
            var login = _mapper.Map<AthletesEntity>(loginRequest);
            var entity = _authorizationToken.Login(login);


            // Generate JWT token for the registered athlete
            var token = _authorization.GenerateTokenForLogin(entity);

            return Ok(new { Token = token });
        }

    }
}

