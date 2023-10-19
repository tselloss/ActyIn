using Athletes.Info.Interface;
using Athletes.Info.Model;
using Athletes.Info.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Athletes.Info.Controller
{
    [Route("api/[controller]")]
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

        [HttpGet("api/users")]
        public async Task<ActionResult<IEnumerable<AthleteInfoDTO>>> GetAllUsersAsync()
        {
            var users = await _athletesInfo.GetAllAthletesAsync();
            if (users == null)
            {
                _logger.LogInformation("We have no users on Db");
                return NoContent();
            }
            return Ok(_mapper.Map<IEnumerable<AthleteInfoDTO>>(users));
        }

        [HttpGet("api/userById/{id}")]
        public async Task<ActionResult<AthleteInfoDTO>> GetUserInfoByIdAsync(int id)
        {
            var user = await _athletesInfo.GetAthletesInfoByIdAsync(id);
            if (user == null)
            {
                _logger.LogInformation($"We have no user on Db with this id: {id} ");
                return NoContent();
            }
            return Ok(_mapper.Map<AthleteInfoDTO>(user));
        }

        [HttpPost("api/createUser")]
        public async Task<ActionResult<AthleteInfo>> CreateUserAsync([FromBody] AthleteInfo athleteInfo)
        {
            var newUser = _mapper.Map<AthleteInfo>(athleteInfo);
            //await _userInfo.CreateUser(newUser);
            //await _userInfoService.SaveChangesAsync();
            return Ok(newUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var users = await _athletesInfo.DeleteAthletesByIdAsync(id);

            if (users == null)
            {
                _logger.LogInformation($"We have no user on Db with this id: {id} ");
                return NoContent();
            }
            //_athletesInfo.DeleteUserAsync(users);
            //await _athleteInfoService.SaveChangesAsync();
            return Ok(users);
        }
    }
}

