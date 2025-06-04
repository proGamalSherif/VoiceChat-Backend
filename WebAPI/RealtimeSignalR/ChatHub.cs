using Microsoft.AspNetCore.SignalR;

namespace WebAPI.RealtimeSignalR
{
    public class ChatHub:Hub
    {
        public async Task JoinRoom(int roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
        }
        public async Task SendMessage(Guid userId, int roomId, string message)
        {
            await Clients.Group(roomId.ToString()).SendAsync("ReceiveMessage", userId, roomId, message);
        }
    }
}
