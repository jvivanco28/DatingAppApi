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
            CreateMap<User, UserForListDto>()
                .ForMember(
                    destinationMember => destinationMember.PhotoUrl,
                    options => { options.MapFrom(user => user.Photos.FirstOrDefault(p => p.IsMain).Url); })
                .ForMember(
                    destinationMember => destinationMember.Age,
                    options => { options.ResolveUsing(user => user.DateOfBirth.CalculateAge()); }
                );

            CreateMap<User, UserForDetailDto>()
                .ForMember(
                    destinationMember => destinationMember.PhotoUrl,
                    options => { options.MapFrom(user => user.Photos.FirstOrDefault(p => p.IsMain).Url); })
                .ForMember(
                    destinationMember => destinationMember.Age,
                    options => { options.ResolveUsing(user => user.DateOfBirth.CalculateAge()); }
                );

            CreateMap<Photo, PhotosForDetailDto>();
            CreateMap<UserForUpdateDto, User>();
        }
    }
}