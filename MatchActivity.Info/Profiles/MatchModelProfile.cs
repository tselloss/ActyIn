using AutoMapper;
using ChooseActivity.Info.Model;
using MatchActivity.Info.Model;
using Postgres.Context.Entities;

namespace MatchActivity.Info.Profiles
{
    public class MatchModelProfile : Profile
    {
        public MatchModelProfile()
        {
            CreateMap<MatchModelInfo, MatchModelEntity>().ReverseMap();
        }
    }
}
