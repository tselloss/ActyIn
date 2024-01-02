using AutoMapper;
using BookingModel.Info.Model;
using Postgres.Context.Entities;

namespace BookingModel.Info.Profiles;

public class BookingInfoProfiles : Profile
{
    public BookingInfoProfiles()
    {
        CreateMap<BookingEntity, BookingModelInfo>().ReverseMap();
        CreateMap<BookingModelInfo, BookingEntity>().ReverseMap();
    }
}
