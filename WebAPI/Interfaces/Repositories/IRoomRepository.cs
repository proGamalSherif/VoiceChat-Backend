using WebAPI.Entities;
using WebAPI.Responses;

namespace WebAPI.Interfaces.Repositories
{
    public interface IRoomRepository
    {
        Task<APIResponse<ICollection<Room>>> GetAllAsync();
        Task<APIResponse<Room>> GetByIdAsync(int id);
        Task<APIResponse<Room>> InsertEntity(Room entity);
        Task<APIResponse<Room>> UpdateEntity(Room entity);
        Task<APIResponse<string>> DeleteEntity(int id);
    }
}
