using Microsoft.AspNetCore.SignalR;

namespace WebAPI.RealtimeSignalR
{
    public class CallHub : Hub
    {
        public static Dictionary<Guid, string> userConnectionMap = new();
        public override Task OnConnectedAsync()
        {
            var userIdStr = Context.GetHttpContext().Request.Query["userId"];
            if (Guid.TryParse(userIdStr, out Guid userId))
            {
                userConnectionMap[userId] = Context.ConnectionId;
            }
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            var userId = userConnectionMap.FirstOrDefault(kvp => kvp.Value == Context.ConnectionId).Key;
            if (userId != Guid.Empty)
            {
                userConnectionMap.Remove(userId);
            }
            return base.OnDisconnectedAsync(exception);
        }
        public async Task StartCall(Guid receiverId, Guid callerId)
        {
            if (userConnectionMap.TryGetValue(receiverId, out string receiverConnectionId))
            {
                await Clients.Client(receiverConnectionId).SendAsync("ReceiveCall", callerId);
            }
        }
        public async Task SendOffer(Guid receiverId, Guid senderId, object offer)
        {
            if (userConnectionMap.TryGetValue(receiverId, out string receiverConnectionId))
            {
                await Clients.Client(receiverConnectionId).SendAsync("ReceiveOffer", senderId, offer);
            }
        }
        public async Task SendAnswer(Guid receiverId, Guid senderId, object answer)
        {
            if (userConnectionMap.TryGetValue(receiverId, out string receiverConnectionId))
            {
                await Clients.Client(receiverConnectionId).SendAsync("ReceiveAnswer", senderId, answer);
            }
        }
        public async Task SendIceCandidate(Guid receiverId, Guid senderId, object candidate)
        {
            if (userConnectionMap.TryGetValue(receiverId, out string receiverConnectionId))
            {
                await Clients.Client(receiverConnectionId).SendAsync("ReceiveIceCandidate", senderId, candidate);
            }
        }
        public async Task EndCall(Guid receiverId, Guid senderId)
        {
            if (userConnectionMap.TryGetValue(receiverId, out string receiverConnectionId))
            {
                await Clients.Client(receiverConnectionId).SendAsync("ReceiveCallEnded", senderId);
            }
        }
    }
}
