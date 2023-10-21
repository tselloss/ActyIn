using Athletes.Info.Interface;
using Athletes.Info.Model;
using Athletes.Info.Repository;
using Athletes.Info.Request;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

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

        [HttpGet("actyin/getAllUsers")]
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

        [HttpGet("actyin/getUserById/{id}")]
        public async Task<ActionResult<AthleteInfoDTO>> GetUserInfoByIdAsync(int id)
        {
            var user = await _athletesInfo.GetAthletesInfoByIdAsync(id);
            if (user == null)
            {
                _logger.LogInformation($"We have no user on Db with this id: {id} ");
                return NoContent();
            }
            var getUset = _mapper.Map<AthleteInfoDTO>(user);
            return Ok(getUset);
        }

        [HttpPost("actyin/createUser")]
        public async Task<ActionResult<AthleteInfo>> CreateUserAsync([FromBody] AthletesRegisterRequest athleteInfoRequest)
        {
            var newUser = _mapper.Map<AthleteInfo>(athleteInfoRequest);
            await _athletesInfo.RegisterAthlete(athleteInfoRequest);
            await _athleteInfoService.SaveChangesAsync();
            return Ok(newUser);
        }

        [HttpDelete("actyin/deleteUserById/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {            
            var users = await _athletesInfo.GetAthletesInfoByIdAsync(id);

            if (users == null)
            {
                _logger.LogInformation($"We have no user on Db with this id: {id} ");
                return NoContent();
            }
            await _athletesInfo.DeleteAthletesByIdAsync(id);
            await _athleteInfoService.SaveChangesAsync();
            return Ok(users);
        }
    }
}

