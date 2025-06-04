using WebAPI.Entities;
using WebAPI.Responses;

namespace WebAPI.Interfaces.Repositories
{
    public interface IApplicationUserRepository
    {
        Task<APIResponse<ICollection<ApplicationUser>>> GetAllAsync();
        Task<APIResponse<ApplicationUser>> GetByIdAsync(Guid id);
        Task<APIResponse<ApplicationUser>> InsertEntity(ApplicationUser user);
        Task<APIResponse<ApplicationUser>> UpdateEntity(ApplicationUser user);
        Task<APIResponse<string>> DeleteEntity(Guid id);
    }
}
