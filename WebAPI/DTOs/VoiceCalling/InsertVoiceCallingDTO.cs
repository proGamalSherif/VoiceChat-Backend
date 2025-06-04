using WebAPI.Entities.Enums;

namespace WebAPI.DTOs.VoiceCalling
{
    public class InsertVoiceCallingDTO
    {
        public Guid ReceiverId { get; set; }
        public Guid CallerId { get; set; }
        public int RoomId { get; set; }
        public int CallingStatus { get; set; }
    }
}
