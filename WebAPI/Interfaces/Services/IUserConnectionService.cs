using WebAPI.DTOs.UserConnection;
using WebAPI.Responses;

namespace WebAPI.Interfaces.Services
{
    public interface IUserConnectionService
    {
        Task<APIResponse<ICollection<ReadUserConnectionDTO>>> GetAllAsync();
        Task<APIResponse<ReadUserConnectionDTO>> GetByIdAsync(int id);
        Task<APIResponse<ReadUserConnectionDTO>> InsertEntity(InsertUserConnectionDTO entitiy);
        Task<APIResponse<ReadUserConnectionDTO>> UpdateEntity(UpdateUserConnectionDTO entitiy);
        Task<APIResponse<string>> DeleteEntity(int id);
        Task<APIResponse<ICollection<ReadUserConnectionDTO>>> GetAllByUserId(Guid userId);
    }
}
