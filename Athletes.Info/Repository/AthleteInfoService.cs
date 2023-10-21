using Athletes.Info.Extension.Methods;
using Athletes.Info.Interface;
using Athletes.Info.Model;
using Athletes.Info.Request;
using Define.Common.Exceptions;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Postgres.Context.DBContext;
using Postgres.Context.Entities;

namespace Athletes.Info.Repository
{
    public class AthleteInfoService : IAthletes
    {

        private readonly NpgsqlContext _context;

        public void DeleteAthletesByIdAsync(AthletesEntity athletesEntity)
        {
            _context.AthletesInfoEntity.Remove(athletesEntity);
        }

        public void EditAthletes(AthletesEditRequest editRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<IEnumerable<AthletesEntity>>> GetAllAthletesAsync()
        {
            return await _context.AthletesInfoEntity.OrderBy(_ => _.AthletesId).ToListAsync();
        }

        public async Task<ActionResult<AthletesEntity>> GetAthletesInfoByIdAsync(int athleteId)
        {
            return await _context.AthletesInfoEntity.Where(_ => _.AthletesId == athleteId).FirstOrDefaultAsync();
        }

        public void LoginAthlete(AthletesLoginRequest loginRequest)
        {
            if (!_context.AthletesInfoEntity.Any(_ => _.Username == loginRequest.Username) || !_context.AthletesInfoEntity.Any(_ => _.Email == loginRequest.Email))
            {
                throw new ControllerExceptionMessage(AthletesExceptionMesseges.UndefinedUserId, loginRequest.Email.ToString());
            }
            AthletesEntity user = _context.AthletesInfoEntity.Where(_ => _.Username == loginRequest.Username || _.Email == loginRequest.Email).First();
            var verifyHashedPass = VerifyPassword.PasswordVerification(loginRequest.Password);
            if (user.Password != verifyHashedPass)
            {
                throw new ControllerExceptionMessage(AthletesExceptionMesseges.UndefinedUserPassword, loginRequest.Username);
            }
        }

        public void RegisterAthlete(AthletesEntity registerRequest)
        {
            if (registerRequest.Email == null || registerRequest.Username == null || registerRequest.Password == null)
            {
                throw new ControllerExceptionMessage(AthletesExceptionMesseges.UndefinedUserId, registerRequest.AthletesId.ToString());
            }
            if (_context.AthletesInfoEntity.Any(u => u.Username == registerRequest.Username))
            {
                throw new ControllerExceptionMessage(AthletesExceptionMesseges.UndefinedUserUsername, registerRequest.Username);
            }
            if (_context.AthletesInfoEntity.Any(u => u.Email == registerRequest.Email))
            {
                throw new ControllerExceptionMessage(AthletesExceptionMesseges.UndefinedUserEmail, registerRequest.Email);
            }

            var hashedPass = PasswordHash.CreatePasswordHash(registerRequest.Password);
            registerRequest.Password = hashedPass;
            _context.AthletesInfoEntity.Add(registerRequest);
            _context.SaveChanges();
        }


        public async Task<bool> SaveChangesAsync(string message)
        {
            try
            {
                return await _context.SaveChangesAsync() >= 0;
            }
            catch (ControllerExceptionMessage)
            {
                throw new ControllerExceptionMessage(message);
            }             
        }
    }
}
