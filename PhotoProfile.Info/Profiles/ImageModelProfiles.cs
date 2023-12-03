using AutoMapper;
using PhotoProfile.Info.Model;
using Postgres.Context.Entities;

namespace PhotoProfile.Info.Profiles
{
    public class ImageModelProfiles : Profile
    {
        public ImageModelProfiles()
        {
            CreateMap<FileEntity, ImageModel>().ReverseMap();
            CreateMap<ApplicationFileEntity, ApplicationImageModel>().ReverseMap();
        }
    }
}
