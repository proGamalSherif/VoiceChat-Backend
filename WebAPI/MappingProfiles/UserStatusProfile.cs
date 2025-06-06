using AutoMapper;
using WebAPI.DTOs.UserStatus;
using WebAPI.Entities;

namespace WebAPI.MappingProfiles
{
    public class UserStatusProfile:Profile
    {
        public UserStatusProfile()
        {
            CreateMap<UserStatus, ReadUserStatusDTO>()
                .ForMember(dest=>dest.RoomName,option=>option.MapFrom(src=>src.Room.RoomName))
                .ForMember(dest=>dest.Username,option=>option.MapFrom(src=>src.User.Username))
                .ReverseMap();
            CreateMap<UserStatus,InsertUserStatusDTO>().ReverseMap();
        }
    }
}
