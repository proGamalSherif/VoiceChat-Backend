using WebAPI.Entities.Enums;

namespace WebAPI.DTOs.VoiceCalling
{
    public class ReadVoiceCallingDTO
    {
        public int VoiceCallingId { get; set; }
        public Guid ReceiverId { get; set; }
        public string ReceiverName { get; set; }
        public Guid CallerId { get; set; }
        public string CallerName { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public CallingStatus CallingStatus { get; set; }
    }
}
