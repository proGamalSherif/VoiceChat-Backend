using AutoMapper;
using WebAPI.DTOs.RoomChat;
using WebAPI.Entities;

namespace WebAPI.MappingProfiles
{
    public class RoomChatProfile : Profile
    {
        public RoomChatProfile()
        {
            CreateMap<RoomChat, ReadRoomChatDTO>()
                .ForMember(dest=>dest.Username,option=>option.MapFrom(src=>src.User.Username))
                .ForMember(dest=>dest.RoomName,option=>option.MapFrom(src=>src.Room.RoomName))
                .ReverseMap();
            CreateMap<RoomChat, InsertRoomChatDTO>().ReverseMap();
            CreateMap<RoomChat, UpdateRoomChatDTO>().ReverseMap();
        }
    }
}
