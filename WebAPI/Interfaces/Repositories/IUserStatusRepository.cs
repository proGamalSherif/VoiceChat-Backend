using WebAPI.Entities;
using WebAPI.Responses;

namespace WebAPI.Interfaces.Repositories
{
    public interface IUserStatusRepository
    {
        Task<APIResponse<UserStatus>> SetUserStatus(UserStatus userStatus);
        Task<APIResponse<bool>> GetUserStatus(Guid userId,int roomId);
        Task<APIResponse<ICollection<UserStatus>>> GetAllUsersOnlineInRoom(int roomId);
        Task<APIResponse<bool>> SetUserOffline(Guid userId, int roomId);
        Task LogoutUser(Guid userId);
    }
}
