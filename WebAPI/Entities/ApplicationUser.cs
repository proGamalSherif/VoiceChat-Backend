using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Entities.Common;

namespace WebAPI.Entities
{
    public class ApplicationUser:BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public virtual ICollection<RoomChat> RoomChats { get; set; }
        public virtual ICollection<UserConnection> UserConnections { get; set; }
        public virtual ICollection<VoiceCalling> CallsMade { get; set; }
        public virtual ICollection<VoiceCalling> CallsReceived { get; set; }
        public virtual ICollection<UserStatus> UserStatuses { get; set; }
    }
}
