using AutoMapper;
using WebAPI.DTOs.ApplicationUser;
using WebAPI.Entities;

namespace WebAPI.MappingProfiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUser, ReadApplicationUserDTO>().ReverseMap();
            CreateMap<ApplicationUser, InsertApplicationUserDTO>().ReverseMap();
            CreateMap<ApplicationUser, UpdateApplicationUserDTO>().ReverseMap();
        }
    }
}
