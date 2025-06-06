using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using WebAPI.DTOs.RoomChat;
using WebAPI.Interfaces.Services;

namespace WebAPI.RealtimeSignalR
{
    public class ChatHub:Hub
    {
        private readonly IRoomChatService roomChatService;
        private readonly IMapper mapper;
        public ChatHub(IRoomChatService _roomChatService,IMapper _mapper)
        {
            roomChatService = _roomChatService;
            mapper = _mapper;
        }
        public async Task JoinRoom(int roomId)
        {
            try
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in JoinRoom: {ex.Message}");
                throw; 
            }
        }
        public async Task SendMessage(InsertRoomChatDTO entityDTO)
        {
            var serviceResponse = await roomChatService.InsertEntity(entityDTO);
            if (serviceResponse.IsSuccess)
            {
                var mappedEntity = mapper.Map<ReadRoomChatDTO>(serviceResponse.Data);
                await Clients.Group(entityDTO.RoomId.ToString()).SendAsync("ReceiveMessage", entityDTO);
            }
        }
    }
}
