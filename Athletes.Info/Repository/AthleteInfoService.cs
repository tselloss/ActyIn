using Athletes.Info.Extension.Methods;
using Athletes.Info.Interface;
using Athletes.Info.Request;
using Athletes.Info.Request.EditRequests;
using Define.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Postgres.Context.DBContext;
using Postgres.Context.Entities;

namespace Athletes.Info.Repository
{
    public class AthleteInfoService : IAthletes
    {

        private readonly NpgsqlContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AthleteInfoService(NpgsqlContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public void DeleteAthletesByIdAsync(AthletesEntity athletesEntity)
        {
            _context.AthletesInfo.Remove(athletesEntity);
        }

        public void EditAthletesFavoriteActivity(AthleteEditFavoriteActivityRequest editFavoriteActivityRequest)
        {            
            var favAct = _context.AthletesInfo.Where(_ => _.FavoriteActivity == editFavoriteActivityRequest.FavoriteActivity).First();
            if (favAct != null)
                favAct.FavoriteActivity = editFavoriteActivityRequest.FavoriteActivity;
            _context.AthletesInfo.Add(favAct);
            _context.SaveChanges();
        }

        public void EditAthletesLocation(AthleteEditLocationRequest athleteEditLocationRequest)
        {
            var favAct = _context.AthletesInfo.Where(_ => _.PostalCode == athleteEditLocationRequest.PostalCode).First();
            if (favAct != null)
                favAct.PostalCode = athleteEditLocationRequest.PostalCode;
            _context.AthletesInfo.Add(favAct);
            _context.SaveChanges();
        }

        public void EditAthletesPassword(AthleteEditPasswordRequest athleteEditPasswordRequest)
        {
            throw new NotImplementedException();
        }

        public void EditAthletesUsernameAndEmail(AthleteEditUsernameAndEmailRequest editUsernameAndEmailRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AthletesEntity>> GetAllAthletesAsync()
        {
            return await _context.AthletesInfo.OrderBy(_ => _.AthletesId).ToListAsync();
        }

        public async Task<AthletesEntity> GetAthletesInfoByIdAsync(int athleteId)
        {
            return await _context.AthletesInfo.Where(_ => _.AthletesId == athleteId).FirstOrDefaultAsync();
        }

        public void LoginAthlete(AthleteLoginRequest loginRequest)
        {
            if (!_context.AthletesInfo.Any(_ => _.Username == loginRequest.Username) || !_context.AthletesInfo.Any(_ => _.Email == loginRequest.Email))
            {
                throw new ControllerExceptionMessage(AthletesExceptionMessages.UndefinedUserId, loginRequest.Email.ToString());
            }
            AthletesEntity user = _context.AthletesInfo.Where(_ => _.Username == loginRequest.Username || _.Email == loginRequest.Email).First();
            var verifyHashedPass = VerifyPassword.PasswordVerification(loginRequest.Password);
            if (user.Password != verifyHashedPass)
            {
                throw new ControllerExceptionMessage(AthletesExceptionMessages.UndefinedUserPassword, loginRequest.Username);
            }
        }

        public void RegisterAthlete(AthletesEntity registerRequest)
        {
            if (registerRequest.Email == null || registerRequest.Username == null || registerRequest.Password == null)
            {
                throw new ControllerExceptionMessage(AthletesExceptionMessages.UndefinedUserId, registerRequest.AthletesId.ToString());
            }
            if (_context.AthletesInfo.Any(u => u.Username == registerRequest.Username))
            {
                throw new ControllerExceptionMessage(AthletesExceptionMessages.UndefinedUserUsername, registerRequest.Username);
            }
            if (_context.AthletesInfo.Any(u => u.Email == registerRequest.Email))
            {
                throw new ControllerExceptionMessage(AthletesExceptionMessages.UndefinedUserEmail, registerRequest.Email);
            }

            var hashedPass = PasswordHash.CreatePasswordHash(registerRequest.Password);
            registerRequest.Password = hashedPass;
            _context.AthletesInfo.Add(registerRequest);
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
