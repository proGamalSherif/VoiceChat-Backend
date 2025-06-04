using Microsoft.AspNetCore.SignalR;

namespace WebAPI.RealtimeSignalR
{
    public class CallHub:Hub
    {
        public async Task JoinRoom(int roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
            await Clients.Group(roomId.ToString()).SendAsync("UserJoined", Context.ConnectionId);
        }
        public async Task SendOffer(string receiverConnectionId, object offer)
        {
            await Clients.Client(receiverConnectionId).SendAsync("ReceiveOffer", Context.ConnectionId, offer);
        }
        public async Task SendAnswer(string receiverConnectionId, object answer)
        {
            await Clients.Client(receiverConnectionId).SendAsync("ReceiveAnswer", Context.ConnectionId, answer);
        }
        public async Task SendIceCandidate(string receiverConnectionId, object candidate)
        {
            await Clients.Client(receiverConnectionId).SendAsync("ReceiveIceCandidate", Context.ConnectionId, candidate);
        }
    }
}
