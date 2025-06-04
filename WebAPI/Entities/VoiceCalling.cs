using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Entities.Common;
using WebAPI.Entities.Enums;

namespace WebAPI.Entities
{
    public class VoiceCalling : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoiceCallingId { get; set; }
        public Guid ReceiverId { get; set; }
        [ForeignKey("ReceiverId")]
        public ApplicationUser Receiver { get; set; }
        public Guid CallerId { get; set; }
        [ForeignKey("CallerId")]
        public ApplicationUser Caller { get; set; }
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        public CallingStatus CallingStatus { get; set; } = CallingStatus.NA;
    }
}
