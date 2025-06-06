using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.DTOs.UserStatus
{
    public class ReadUserStatusDTO
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public bool IsLogged { get; set; } 
    }
}
