namespace WebAPI.DTOs.RoomChat
{
    public class ReadRoomChatDTO
    {
        public int ChatId { get; set; }
        public string ChatMessage { get; set; }
        public DateTime CreatedIn { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
    }
}
