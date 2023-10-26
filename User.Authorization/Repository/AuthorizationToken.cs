using Define.Common.Exceptions;
using Define.Common.Extension.Methods;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Postgres.Context.DBContext;
using Postgres.Context.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using User.Authorization.Interface;
using User.Authorization.Request.ComesInRequests;

namespace User.Authorization.Repository
{
    public class AuthorizationToken : IAuthorizationToken
    {
        private readonly IConfiguration _configuration;

        private readonly NpgsqlContext _context;

        public AuthorizationToken(IConfiguration configuration , NpgsqlContext npgsqlContext)
        {
            _configuration = configuration;
            _context = npgsqlContext;
        }

        public AthleteLoginRequest Login(AthletesEntity loginRequest)
        {

            if (loginRequest.Email == null || loginRequest.Username == null || loginRequest.Password == null)
            {
                throw new ControllerExceptionMessage(AthletesExceptionMessages.NullField);
            }

            if (!_context.AthletesInfo.Any(_ => _.Username == loginRequest.Username) && !_context.AthletesInfo.Any(_ => _.Email == loginRequest.Email))
            {
                throw new ControllerExceptionMessage(AthletesExceptionMessages.UndefinedUserUsername, loginRequest.Username);
            }

            var user = _context.AthletesInfo.Where(_ => _.Username == loginRequest.Username || _.Email == loginRequest.Email).First();
            var verifyHashedPass = VerifyPassword.PasswordVerification(loginRequest.Password);

            if (user.Password != verifyHashedPass)
            {
                throw new ControllerExceptionMessage(AthletesExceptionMessages.UndefinedUserUsername, loginRequest.Username);
            }

            var athleteLogin = ToLoginAthlete(user);

            return athleteLogin;
        }

        public TokenForLogin GenerateTokenForLogin(AthleteLoginRequest athleteLoginRequest)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:SecretForKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, athleteLoginRequest.Username),
                new Claim(ClaimTypes.Email, athleteLoginRequest.Email),
                // Add more claims as needed
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["AppSettings:Issuer"],
                audience: _configuration["AppSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(90),
                signingCredentials: credentials
            );
            var newEntity = ToLoginAthlete(athleteLoginRequest);
            newEntity.Token = new JwtSecurityTokenHandler().WriteToken(token);

            return newEntity;
        }

        public TokenForRegister GenerateTokenForRegister(AthletesEntity registeredAthlete)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:SecretForKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, registeredAthlete.Username),
            new Claim(ClaimTypes.Email, registeredAthlete.Email),
            // Add more claims as needed
        };

            var token = new JwtSecurityToken(
                issuer: _configuration["AppSettings:Issuer"],
                audience: _configuration["AppSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(90),
                signingCredentials: credentials
            );
            var newEntity = ToRegisterAthlete(registeredAthlete);
            newEntity.Token = new JwtSecurityTokenHandler().WriteToken(token);

            return newEntity;
        }

        private AthleteLoginRequest ToLoginAthlete(AthletesEntity athletesEntity) => new AthleteLoginRequest
        {
            Email = athletesEntity.Email,
            Password = athletesEntity.Password,
            Username = athletesEntity.Username
        };

        private TokenForLogin ToLoginAthlete(AthleteLoginRequest athleteLoginRequest) => new TokenForLogin
        {
            Email = athleteLoginRequest.Email,
            Password = athleteLoginRequest.Password,
            Username = athleteLoginRequest.Username
        };

        private TokenForRegister ToRegisterAthlete(AthletesEntity athleteRegisterRequest) => new TokenForRegister
        {
            Address = athleteRegisterRequest.Address,
            City = athleteRegisterRequest.City,
            Email = athleteRegisterRequest.Email,
            Password = athleteRegisterRequest.Password,
            PostalCode = athleteRegisterRequest.PostalCode,
            Role = athleteRegisterRequest.Role,
            Username = athleteRegisterRequest.Username,
            FavoriteActivity = athleteRegisterRequest?.FavoriteActivity,
        };
    }
}
