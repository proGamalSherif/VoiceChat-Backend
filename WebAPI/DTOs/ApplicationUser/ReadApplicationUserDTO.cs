namespace WebAPI.DTOs.ApplicationUser
{
    public class ReadApplicationUserDTO:BaseApplicationUserDTO
    {
        public Guid UserId { get; set; }
        public DateTime CreatedIn { get; set; }
    }
}
