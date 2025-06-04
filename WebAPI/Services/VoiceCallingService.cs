using AutoMapper;
using WebAPI.DTOs.VoiceCalling;
using WebAPI.Entities;
using WebAPI.Interfaces.Repositories;
using WebAPI.Interfaces.Services;
using WebAPI.Responses;
namespace WebAPI.Services
{
    public class VoiceCallingService : IVoiceCallingService
    {
        private readonly IVoiceCallingRepository voiceCallingRepository;
        private readonly IMapper mapper;
        public VoiceCallingService(IVoiceCallingRepository _voiceCallingRepository, IMapper _mapper)
        {
            voiceCallingRepository = _voiceCallingRepository;
            mapper = _mapper;
        }
        public async Task<APIResponse<string>> DeleteEntity(int id)
        {
            return await voiceCallingRepository.DeleteEntity(id);
        }
        public async Task<APIResponse<ICollection<ReadVoiceCallingDTO>>> GetAllAsync()
        {
            var result = await voiceCallingRepository.GetAllAsync();
            if (!result.IsSuccess || result.Data == null)
                return APIResponse<ICollection<ReadVoiceCallingDTO>>.Failure(result.Message);
            var mappedResult = mapper.Map<ICollection<ReadVoiceCallingDTO>>(result.Data);
            return APIResponse<ICollection<ReadVoiceCallingDTO>>.Success(result.Message, mappedResult);
        }
        public async Task<APIResponse<ReadVoiceCallingDTO>> GetByIdAsync(int id)
        {
            var result = await voiceCallingRepository.GetByIdAsync(id);
            if (!result.IsSuccess || result.Data == null)
                return APIResponse<ReadVoiceCallingDTO>.Failure(result.Message);
            var mappedResult = mapper.Map<ReadVoiceCallingDTO>(result.Data);
            return APIResponse<ReadVoiceCallingDTO>.Success(result.Message, mappedResult);
        }
        public async Task<APIResponse<ReadVoiceCallingDTO>> InsertEntity(InsertVoiceCallingDTO entitiy)
        {
            var mappedInput = mapper.Map<VoiceCalling>(entitiy);
            var result = await voiceCallingRepository.InsertEntity(mappedInput);
            if (!result.IsSuccess || result.Data == null)
                return APIResponse<ReadVoiceCallingDTO>.Failure(result.Message);
            var mappedResult = mapper.Map<ReadVoiceCallingDTO>(result.Data);
            return APIResponse<ReadVoiceCallingDTO>.Success(result.Message, mappedResult);
        }
        public async Task<APIResponse<ReadVoiceCallingDTO>> UpdateEntity(UpdateVoiceCallingDTO entitiy)
        {
            var mappedInput = mapper.Map<VoiceCalling>(entitiy);
            var result = await voiceCallingRepository.UpdateEntity(mappedInput);
            if (!result.IsSuccess || result.Data == null)
                return APIResponse<ReadVoiceCallingDTO>.Failure(result.Message);
            var mappedResult = mapper.Map<ReadVoiceCallingDTO>(result.Data);
            return APIResponse<ReadVoiceCallingDTO>.Success(result.Message, mappedResult);
        }
    }
}
