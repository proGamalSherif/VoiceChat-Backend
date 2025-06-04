namespace WebAPI.DTOs.UserConnection
{
    public class UpdateUserConnectionDTO
    {
        public int ConnectionId { get; set; }
        public Guid UserId { get; set; }
        public int RoomId { get; set; }
    }

}
