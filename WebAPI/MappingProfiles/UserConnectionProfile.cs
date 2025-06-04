using AutoMapper;
using WebAPI.DTOs.UserConnection;
using WebAPI.Entities;

namespace WebAPI.MappingProfiles
{
    public class UserConnectionProfile : Profile
    {
        public UserConnectionProfile()
        {
            CreateMap<UserConnection, ReadUserConnectionDTO>()
                .ForMember(dest=>dest.Username,option=>option.MapFrom(src=>src.User.Username))
                .ForMember(dest=>dest.RoomName,option=>option.MapFrom(src=>src.Room.RoomName))
                .ReverseMap();
            CreateMap<UserConnection, InsertUserConnectionDTO>().ReverseMap();
            CreateMap<UserConnection, UpdateUserConnectionDTO>().ReverseMap();
        }
    }
}
