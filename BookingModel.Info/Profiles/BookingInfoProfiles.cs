using Athletes.Info.Model;
using Athletes.Info.Request.EditRequests;
using AutoMapper;
using BookingModel.Info.Model;
using Postgres.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingModel.Info.Profiles
{
    public class BookingInfoProfiles : Profile
    {
        public BookingInfoProfiles()
        {
            CreateMap<BookingEntity, BookingModelInfo>().ReverseMap();
            CreateMap<BookingModelInfo, BookingEntity>().ReverseMap();
        }
    }
}
