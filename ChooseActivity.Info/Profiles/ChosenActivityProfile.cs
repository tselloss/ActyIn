using AutoMapper;
using ChooseActivity.Info.Model;
using Postgres.Context.Entities;

namespace MatchActivityInfo.Profiles;

public class ChosenActivityProfile : Profile
{
    public ChosenActivityProfile()
    {
        CreateMap<ChooseActivityInfo, ChosenActivityEntity>().ReverseMap();
    }
}
