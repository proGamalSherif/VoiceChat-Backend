using WebAPI.DTOs.UserStatus;
using WebAPI.Responses;

namespace WebAPI.Interfaces.Services
{
    public interface IUserStatusService
    {
        Task<APIResponse<ReadUserStatusDTO>> SetUserStatus(InsertUserStatusDTO userStatus);
        Task<APIResponse<bool>> GetUserStatus(Guid userId, int roomId);
        Task<APIResponse<ICollection<ReadUserStatusDTO>>> GetAllUsersOnlineInRoom(int roomId);
        Task LogoutUser(Guid userId);
    }
}
