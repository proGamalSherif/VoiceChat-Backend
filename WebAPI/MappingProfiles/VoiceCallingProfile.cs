using AutoMapper;
using WebAPI.DTOs.VoiceCalling;
using WebAPI.Entities;

namespace WebAPI.MappingProfiles
{
    public class VoiceCallingProfile : Profile
    {
        public VoiceCallingProfile()
        {
            CreateMap<VoiceCalling, ReadVoiceCallingDTO>()
                .ForMember(dest=>dest.ReceiverName,option=>option.MapFrom(src=>src.Receiver.Username))
                .ForMember(dest=>dest.CallerName,option=>option.MapFrom(src=>src.Caller.Username))
                .ForMember(dest=>dest.RoomName,option=>option.MapFrom(src=>src.Room.RoomName))
                .ReverseMap();
            CreateMap<VoiceCalling, InsertVoiceCallingDTO>().ReverseMap();
            CreateMap<VoiceCalling, UpdateVoiceCallingDTO>().ReverseMap();
        }
    }
}
