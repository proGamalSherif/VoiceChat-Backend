using AutoMapper;
using WebAPI.DTOs.Room;
using WebAPI.Entities;

namespace WebAPI.MappingProfiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, ReadRoomDTO>().ReverseMap();
            CreateMap<Room, InsertRoomDTO>().ReverseMap();
            CreateMap<Room, UpdateRoomDTO>().ReverseMap();
        }
    }
}
