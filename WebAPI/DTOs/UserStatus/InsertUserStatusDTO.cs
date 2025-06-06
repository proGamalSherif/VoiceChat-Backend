namespace WebAPI.DTOs.UserStatus
{
    public class InsertUserStatusDTO
    {
        public Guid UserId { get; set; }
        public int RoomId { get; set; }
        public bool IsLogged { get; set; }
    }
}
