using Athletes.Info.Model;
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
        }
    }
}
