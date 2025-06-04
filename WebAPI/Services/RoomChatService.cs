using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using WebAPI.DTOs.RoomChat;
using WebAPI.Entities;
using WebAPI.Interfaces.Repositories;
using WebAPI.Interfaces.Services;
using WebAPI.RealtimeSignalR;
using WebAPI.Responses;

namespace WebAPI.Services
{
    public class RoomChatService : IRoomChatService
    {
        private readonly IRoomChatRepository roomChatRepository;
        private readonly IRoomRepository roomRepository;
        private readonly IMapper mapper;
        private readonly IHubContext<ChatHub> hubContext;
        public RoomChatService(IRoomChatRepository _roomChatRepository, IMapper _mapper, IHubContext<ChatHub> _hubContext, IRoomRepository _roomRepository)
        {
            roomChatRepository = _roomChatRepository;
            mapper = _mapper;
            hubContext = _hubContext;
            roomRepository = _roomRepository;
        }
        public async Task<APIResponse<string>> DeleteEntity(int id)
        {
            return await roomChatRepository.DeleteEntity(id);
        }
        public async Task<APIResponse<ICollection<ReadRoomChatDTO>>> GetAllAsync()
        {
            var result = await roomChatRepository.GetAllAsync();
            if (!result.IsSuccess)
                return APIResponse<ICollection<ReadRoomChatDTO>>.Failure(result.Message);
            var mappedResult = mapper.Map<ICollection<ReadRoomChatDTO>>(result.Data);
            return APIResponse<ICollection<ReadRoomChatDTO>>.Success(result.Message, mappedResult);
        }
        public async Task<APIResponse<ReadRoomChatDTO>> GetByIdAsync(int id)
        {
            var result = await roomChatRepository.GetByIdAsync(id);
            if (!result.IsSuccess)
                return APIResponse<ReadRoomChatDTO>.Failure(result.Message);
            var mappedResult = mapper.Map<ReadRoomChatDTO>(result.Data);
            return APIResponse<ReadRoomChatDTO>.Success(result.Message, mappedResult);
        }
        public async Task<APIResponse<ReadRoomChatDTO>> InsertEntity(InsertRoomChatDTO entitiy)
        {
            var mappedInput = mapper.Map<RoomChat>(entitiy);
            var result = await roomChatRepository.InsertEntity(mappedInput);
            if (!result.IsSuccess)
                return APIResponse<ReadRoomChatDTO>.Failure(result.Message);
            var mappedResult = mapper.Map<ReadRoomChatDTO>(result.Data);
            await hubContext.Clients.Group(entitiy.RoomId.ToString())
                .SendAsync("ReceiveMessage",mappedResult);
            return APIResponse<ReadRoomChatDTO>.Success(result.Message, mappedResult);
        }
        public async Task<APIResponse<ReadRoomChatDTO>> UpdateEntity(UpdateRoomChatDTO entitiy)
        {
            var mappedInput = mapper.Map<RoomChat>(entitiy);
            var result = await roomChatRepository.UpdateEntity(mappedInput);
            if (!result.IsSuccess)
                return APIResponse<ReadRoomChatDTO>.Failure(result.Message);
            var mappedResult = mapper.Map<ReadRoomChatDTO>(result.Data);
            return APIResponse<ReadRoomChatDTO>.Success(result.Message, mappedResult);
        }
    }
}
