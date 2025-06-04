using WebAPI.Entities;
using WebAPI.Responses;

namespace WebAPI.Interfaces.Repositories
{
    public interface IUserConnectionRepository
    {
        Task<APIResponse<ICollection<UserConnection>>> GetAllAsync();
        Task<APIResponse<UserConnection>> GetByIdAsync(int id);
        Task<APIResponse<UserConnection>> InsertEntity(UserConnection entity);
        Task<APIResponse<UserConnection>> UpdateEntity(UserConnection entity);
        Task<APIResponse<string>> DeleteEntity(int id);
        Task<APIResponse<ICollection<UserConnection>>> GetAllByUserId(Guid userId);
    }
}
