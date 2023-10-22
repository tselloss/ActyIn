using Athletes.Info.Model;
using Athletes.Info.Request.EditRequests;
using AutoMapper;
using Postgres.Context.Entities;

namespace Athletes.Info.Profiles
{
    public class AthleteProfile : Profile
    {
        public AthleteProfile()
        {
            CreateMap<AthletesEntity, AthleteInfo>().ReverseMap();
            CreateMap<AthletesEntity, AthleteInfoDTO>().ReverseMap();
            CreateMap<AthleteInfo, AthletesEntity>().ReverseMap();
            CreateMap<AthleteEditFavoriteActivityRequest, AthletesEntity>().ReverseMap();
            CreateMap<AthleteEditLocationRequest, AthletesEntity>().ReverseMap();
            CreateMap<AthleteEditUsernameAndEmailRequest, AthletesEntity>().ReverseMap();
            CreateMap<AthleteEditPasswordRequest, AthletesEntity>().ReverseMap();
        }
    }
}
