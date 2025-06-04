namespace WebAPI.DTOs.VoiceCalling
{
    public class UpdateVoiceCallingDTO
    {
        public int VoiceCallingId { get; set; }
        public Guid ReceiverId { get; set; }
        public Guid CallerId { get; set; }
        public int RoomId { get; set; }
    }
}
