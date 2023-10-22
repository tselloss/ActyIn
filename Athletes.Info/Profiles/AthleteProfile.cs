using Athletes.Info.Model;
using AutoMapper;
using Postgres.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athletes.Info.Profiles
{
    public class AthleteProfile : Profile
    {
        public AthleteProfile() {
            CreateMap<AthletesEntity, AthleteInfo>().ReverseMap();
            CreateMap<AthletesEntity, AthleteInfoDTO>().ReverseMap();
            CreateMap<AthleteInfo, AthletesEntity>().ReverseMap();
        }
    }
}
