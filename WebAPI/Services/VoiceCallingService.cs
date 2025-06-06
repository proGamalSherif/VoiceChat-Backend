using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using WebAPI.DTOs.VoiceCalling;
using WebAPI.Entities;
using WebAPI.Interfaces.Repositories;
using WebAPI.Interfaces.Services;
using WebAPI.RealtimeSignalR;
using WebAPI.Responses;
namespace WebAPI.Services
{
    public class VoiceCallingService : IVoiceCallingService
    {
        private readonly IVoiceCallingRepository voiceCallingRepository;
        private readonly IMapper mapper;
        private readonly IHubContext<CallHub> callHub;
        public VoiceCallingService(IVoiceCallingRepository _voiceCallingRepository, IMapper _mapper, IHubContext<CallHub> _callHub)
        {
            voiceCallingRepository = _voiceCallingRepository;
            mapper = _mapper;
            callHub = _callHub;
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
        public async Task<APIResponse<ReadVoiceCallingDTO>> InsertEntity(InsertVoiceCallingDTO entity)
        {
            var mappedInput = mapper.Map<VoiceCalling>(entity);
            var result = await voiceCallingRepository.InsertEntity(mappedInput);
            if (!result.IsSuccess || result.Data == null)
                return APIResponse<ReadVoiceCallingDTO>.Failure(result.Message);
            var mappedResult = mapper.Map<ReadVoiceCallingDTO>(result.Data);
            if (CallHub.userConnectionMap.TryGetValue(entity.ReceiverId, out string receiverConnectionId))
            {
                await callHub.Clients.Client(receiverConnectionId).SendAsync("ReceiveCall", entity.CallerId);
            }

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
