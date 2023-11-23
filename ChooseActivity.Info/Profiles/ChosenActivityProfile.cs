using Athletes.Info.Model;
using Athletes.Info.Request.EditRequests;
using AutoMapper;
using ChooseActivity.Info.Model;
using Postgres.Context.Entities;

namespace Athletes.Info.Profiles
{
    public class ChosenActivityProfile : Profile
    {
        public ChosenActivityProfile()
        {
            CreateMap<ChooseActivityInfo, ChosenActivityEntity>().ReverseMap();
            CreateMap<ChosenActivityEntity, ChooseActivityInfo>().ReverseMap();
        }
    }
}
