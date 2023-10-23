using Athletes.Info.Request.ComesInRequests;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Athletes.Info.Extension.Methods
{
    public class ToAuthorizedUser
    {

        private readonly IConfiguration _configuration;
        public TokenForLogin ToRegisterAthlete(AthleteLoginRequest athleteLoginRequest) => new TokenForLogin
        {
            Email = athleteLoginRequest.Email,
            Password = athleteLoginRequest.Password,
            Username = athleteLoginRequest.Username,
            Token = GenerateJWTWebToken(athleteLoginRequest)
        };

        public TokenForRegister ToRegisterAthlete(AthleteRegisterRequest athleteRegisterRequest) => new TokenForRegister
        {
            Address = athleteRegisterRequest.Address,
            City = athleteRegisterRequest.City,
            Email = athleteRegisterRequest.Email,
            Password = athleteRegisterRequest.Password,
            PostalCode = athleteRegisterRequest.PostalCode,
            Role = athleteRegisterRequest.Role,
            Username = athleteRegisterRequest.Username,
            FavoriteActivity = athleteRegisterRequest?.FavoriteActivity,
            Token = GenerateJWTWebToken(athleteRegisterRequest)
        };

        private string GenerateJWTWebToken(AthleteLoginRequest athleteLoginRequest)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:SecretForKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Create claims
            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.Name, athleteLoginRequest.Username),
                 new Claim(ClaimTypes.Email, athleteLoginRequest.Email),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["AppSettings:Issuer"],
                audience: _configuration["AppSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(90),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private string GenerateJWTWebToken(AthleteRegisterRequest athleteRegisterRequest)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:SecretForKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Create claims
            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.Name, athleteRegisterRequest.Username),
                 new Claim(ClaimTypes.Email, athleteRegisterRequest.Email),
                 new Claim(ClaimTypes.StreetAddress, athleteRegisterRequest.Address),
            };

            var token = new JwtSecurityToken(
               issuer: _configuration["AppSettings:Issuer"],
               audience: _configuration["AppSettings:Audience"],
               claims: claims,
               expires: DateTime.UtcNow.AddMinutes(90),
               signingCredentials: credentials
           );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
