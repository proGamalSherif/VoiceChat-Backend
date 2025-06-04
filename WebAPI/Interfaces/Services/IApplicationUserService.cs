using WebAPI.DTOs.ApplicationUser;
using WebAPI.Responses;

namespace WebAPI.Interfaces.Services
{
    public interface IApplicationUserService
    {
        Task<APIResponse<ICollection<ReadApplicationUserDTO>>> GetAllAsync();
        Task<APIResponse<ReadApplicationUserDTO>> GetByIdAsync(Guid id);
        Task<APIResponse<ReadApplicationUserDTO>> InsertEntity(InsertApplicationUserDTO entitiy);
        Task<APIResponse<ReadApplicationUserDTO>> UpdateEntity(UpdateApplicationUserDTO entitiy);
        Task<APIResponse<string>> DeleteEntity(Guid id);
    }
}
