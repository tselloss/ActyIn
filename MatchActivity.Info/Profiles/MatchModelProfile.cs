using AutoMapper;
using ChooseActivity.Info.Model;
using Postgres.Context.Entities;

namespace MatchActivity.Info.Profiles
{
    public class MatchModelProfile : Profile
    {
        public MatchModelProfile()
        {
            CreateMap<ChooseActivityInfo, ChosenActivityEntity>().ReverseMap();
            CreateMap<ChosenActivityEntity, ChooseActivityInfo>().ReverseMap();
        }
    }
}
