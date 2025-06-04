namespace WebAPI.Entities.Common
{
    public class BaseEntity
    {
        public DateTime CreatedIn { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
    }
}
