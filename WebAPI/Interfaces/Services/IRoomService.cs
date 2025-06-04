using WebAPI.DTOs.Room;
using WebAPI.Responses;

namespace WebAPI.Interfaces.Services
{
    public interface IRoomService
    {
        Task<APIResponse<ICollection<ReadRoomDTO>>> GetAllAsync();
        Task<APIResponse<ReadRoomDTO>> GetByIdAsync(int id);
        Task<APIResponse<ReadRoomDTO>> InsertEntity(InsertRoomDTO entitiy);
        Task<APIResponse<ReadRoomDTO>> UpdateEntity(UpdateRoomDTO entitiy);
        Task<APIResponse<string>> DeleteEntity(int id);
        Task<APIResponse<ReadRoomDTO>> InsertEntityWithUser(Guid userId, InsertRoomDTO entity);
    }
}
