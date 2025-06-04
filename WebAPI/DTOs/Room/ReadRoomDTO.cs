using WebAPI.DTOs.RoomChat;

namespace WebAPI.DTOs.Room
{
    public class ReadRoomDTO
    {
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public DateTime CreatedIn { get; set; }
        public DateTime ClosedTime { get; set; }
        public IList<ReadRoomChatDTO> RoomChats { get; set; } = new List<ReadRoomChatDTO>();
    }
}
