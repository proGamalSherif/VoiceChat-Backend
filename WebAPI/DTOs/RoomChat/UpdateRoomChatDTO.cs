namespace WebAPI.DTOs.RoomChat
{
    public class UpdateRoomChatDTO
    {
        public int ChatId { get; set; }
        public string ChatMessage { get; set; }
        public Guid UserId { get; set; }
        public int RoomId { get; set; }
    }
}
