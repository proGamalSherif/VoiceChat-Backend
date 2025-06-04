using WebAPI.Entities;
using WebAPI.Responses;

namespace WebAPI.Interfaces.Repositories
{
    public interface IRoomChatRepository
    {
        Task<APIResponse<ICollection<RoomChat>>> GetAllAsync();
        Task<APIResponse<RoomChat>> GetByIdAsync(int id);
        Task<APIResponse<RoomChat>> InsertEntity(RoomChat entity);
        Task<APIResponse<RoomChat>> UpdateEntity(RoomChat entity);
        Task<APIResponse<string>> DeleteEntity(int id);
        Task<APIResponse<ICollection<RoomChat>>> GetByRoomId(int id);
    }
}
