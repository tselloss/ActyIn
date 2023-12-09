using AutoMapper;
using Postgres.Context.Entities;
using User.Authorization.Request.ComesInRequests;

namespace User.Authorization.Profiles;

public class AuthorizationProfile : Profile
{
    public AuthorizationProfile()
    {
        CreateMap<AthletesEntity, AthleteLoginRequest>().ReverseMap();
    }
}
