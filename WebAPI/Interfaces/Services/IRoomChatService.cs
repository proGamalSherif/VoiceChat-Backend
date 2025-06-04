using WebAPI.DTOs.RoomChat;
using WebAPI.Responses;

namespace WebAPI.Interfaces.Services
{
    public interface IRoomChatService
    {
        Task<APIResponse<ICollection<ReadRoomChatDTO>>> GetAllAsync();
        Task<APIResponse<ReadRoomChatDTO>> GetByIdAsync(int id);
        Task<APIResponse<ReadRoomChatDTO>> InsertEntity(InsertRoomChatDTO entitiy);
        Task<APIResponse<ReadRoomChatDTO>> UpdateEntity(UpdateRoomChatDTO entitiy);
        Task<APIResponse<string>> DeleteEntity(int id);
    }
}
