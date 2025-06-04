using Microsoft.AspNetCore.SignalR;
using WebAPI.DTOs.RoomChat;

namespace WebAPI.RealtimeSignalR
{
    public class ChatHub:Hub
    {
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
        public async Task SendMessage(ReadRoomChatDTO entityDTO)
        {
            await Clients.Group(entityDTO.RoomId.ToString()).SendAsync("ReceiveMessage", entityDTO);
        }
    }
}
