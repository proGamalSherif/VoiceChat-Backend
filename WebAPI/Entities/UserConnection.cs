using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAPI.Entities.Common;

namespace WebAPI.Entities
{
    public class UserConnection:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConnectionId { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
    }
}
