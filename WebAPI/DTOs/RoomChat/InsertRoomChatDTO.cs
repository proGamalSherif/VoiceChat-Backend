namespace WebAPI.DTOs.RoomChat
{
    public class InsertRoomChatDTO
    {
        public string ChatMessage { get; set; }
        public Guid UserId { get; set; }
        public int RoomId { get; set; }
    }
}
