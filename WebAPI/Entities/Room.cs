using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Entities.Common;

namespace WebAPI.Entities
{
    public class Room: BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public DateTime ClosedTime { get; set; }
        public virtual ICollection<RoomChat> RoomChats { get; set; }
        public virtual ICollection<UserConnection> UserConnections { get; set; }
        public virtual ICollection<VoiceCalling> VoiceCallings { get; set; }
        public virtual ICollection<UserStatus> UserStatuses { get; set; }
    }
}
