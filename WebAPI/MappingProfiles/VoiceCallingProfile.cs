using AutoMapper;
using WebAPI.DTOs.VoiceCalling;
using WebAPI.Entities;

namespace WebAPI.MappingProfiles
{
    public class VoiceCallingProfile : Profile
    {
        public VoiceCallingProfile()
        {
            CreateMap<VoiceCalling, ReadVoiceCallingDTO>().ReverseMap();
            CreateMap<VoiceCalling, InsertVoiceCallingDTO>().ReverseMap();
            CreateMap<VoiceCalling, UpdateVoiceCallingDTO>().ReverseMap();
        }
    }
}
