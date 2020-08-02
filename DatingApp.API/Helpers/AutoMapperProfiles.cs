using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<user, UserForListDto>().ForMember(dest => dest.PhotoUrl, 
                opt => opt.MapFrom(src => src.Photo.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateofBirth.CalculateAge()));
            CreateMap<user, UserForDetailedDto>().ForMember(dest => dest.PhotoUrl, 
                opt => opt.MapFrom(src => src.Photo.FirstOrDefault(p => p.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateofBirth.CalculateAge()));
            CreateMap<Photo, PhotosForDetailDto>();
        }
    }
}