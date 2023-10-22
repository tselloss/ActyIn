using Athletes.Info.Interface;
using Athletes.Info.Model;
using Athletes.Info.Repository;
using AutoMapper;
using Define.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Postgres.Context.Entities;

namespace Athletes.Info.Controller
{
    [Route("actyin/[controller]")]
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
                _logger.LogInformation(AthletesExceptionMesseges.UndefinedUsers);
                return NoContent();
            }
            return Ok(_mapper.Map<IEnumerable<AthleteInfoDTO>>(users));
        }

        [HttpGet("actyin/getUserById/{id}")]
        public async Task<ActionResult<AthletesEntity>> GetUserInfoByIdAsync(int id)
        {
            var user = await _athletesInfo.GetAthletesInfoByIdAsync(id);
            if (user == null)
            {
                _logger.LogInformation(AthletesExceptionMesseges.UndefinedUserId + $"{id}");
                return NoContent();
            }
            var getUset = _mapper.Map<AthleteInfoDTO>(user);
            return Ok(getUset);
        }

        [HttpDelete("actyin/deleteUserById/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var users = await _athletesInfo.GetAthletesInfoByIdAsync(id);

            if (users == null)
            {
                _logger.LogInformation(AthletesExceptionMesseges.UndefinedUserId + $"{id}");
                return NoContent();
            }
            var newUser = _mapper.Map<AthletesEntity>(users);
            _athletesInfo.DeleteAthletesByIdAsync(newUser);

            await _athleteInfoService.SaveChangesAsync(AthletesExceptionMesseges.AthleteCanNotDeleted);
            return Ok(users);
        }
    }
}

