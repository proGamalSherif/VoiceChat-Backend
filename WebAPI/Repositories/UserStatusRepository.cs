using Microsoft.EntityFrameworkCore;
using WebAPI.DBContext;
using WebAPI.Entities;
using WebAPI.Interfaces.Repositories;
using WebAPI.Responses;

namespace WebAPI.Repositories
{
    public class UserStatusRepository : IUserStatusRepository
    {
        private readonly VoiceDBContext db;
        public UserStatusRepository(VoiceDBContext _db)
        {
            db = _db;
        }

        public async Task<APIResponse<ICollection<UserStatus>>> GetAllUsersOnlineInRoom(int roomId)
        {
            var users = await db.UserStatuses
                .Where(us => us.RoomId == roomId && us.IsLogged == true)
                .Include(u=>u.User)
                .Include(r=>r.Room)
                .ToListAsync();
            if (users.Count == 0)
                return APIResponse<ICollection<UserStatus>>.Failure("No Users Found for this Room");
            return APIResponse<ICollection<UserStatus>>.Success("Users Found Successfully", users);
        }

        public async Task<APIResponse<bool>> GetUserStatus(Guid userId, int roomId)
        {
            var status = await db.UserStatuses
                .Where(st => st.UserId == userId && st.RoomId == roomId)
                .OrderByDescending(s => s.Id)
                .FirstOrDefaultAsync();
            if (status == null)
                return APIResponse<bool>.Failure("No Records Found");
            return APIResponse<bool>.Success(data: status.IsLogged);
        }

        public async Task LogoutUser(Guid userId)
        {
            var allRooms = await db.UserStatuses.Where(u => u.UserId == userId).ToListAsync();
            foreach(var room in allRooms)
            {
                room.IsLogged = false;
            }
            await db.SaveChangesAsync();
        }

        public async Task<APIResponse<bool>> SetUserOffline(Guid userId, int roomId)
        {
            var result = await db.UserStatuses
                .Where(us => us.IsLogged && us.RoomId == roomId && us.UserId == userId)
                .ToListAsync();
            foreach(var status in result)
            {
                status.IsLogged = false;
            }
            await db.SaveChangesAsync();
            return APIResponse<bool>.Success(data: true);
        }

        public async Task<APIResponse<UserStatus>> SetUserStatus(UserStatus userStatus)
        {
            await db.UserStatuses.AddAsync(userStatus);
            await db.SaveChangesAsync();
            return APIResponse<UserStatus>.Success(message:"User Status Updated Successfully",data: userStatus);
        }
    }
}
