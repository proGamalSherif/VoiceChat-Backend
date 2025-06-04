namespace WebAPI.DTOs.UserConnection
{
    public class ReadUserConnectionDTO
    {
        public int ConnectionId { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
    }

}
