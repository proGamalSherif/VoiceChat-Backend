using Microsoft.EntityFrameworkCore;
using WebAPI.DBContext;
using WebAPI.Entities;
using WebAPI.Interfaces.Repositories;
using WebAPI.Responses;

namespace WebAPI.Repositories
{
    public class UserConnectionRepository : IUserConnectionRepository
    {
        private readonly VoiceDBContext db;
        public UserConnectionRepository(VoiceDBContext _db)
        {
            db = _db;
        }
        public async Task<APIResponse<string>> DeleteEntity(int id)
        {
            var response = await GetByIdAsync(id);
            if (!response.IsSuccess || response.Data == null)
                return APIResponse<string>.Failure("User Connection Not Found");

            var userConnection = response.Data;
            userConnection.IsDeleted = true;
            await db.SaveChangesAsync();
            return APIResponse<string>.Success("User Connection Deleted Successfully");
        }

        public async Task<APIResponse<ICollection<UserConnection>>> GetAllAsync()
        {
            var userConnections = await db.UserConnections
                .Where(uc => !uc.IsDeleted)
                .ToListAsync();
            if (userConnections.Count == 0)
                return APIResponse<ICollection<UserConnection>>.Failure("Not User Connections Found");
            return APIResponse<ICollection<UserConnection>>.Success("User Connections Found Successfully", userConnections);
        }
        public async Task<APIResponse<ICollection<UserConnection>>> GetAllByUserId(Guid userId)
        {
            var connections = db.UserConnections
                .Include(u=>u.User)
                .Include(r=>r.Room)
                .Where(uc => !uc.IsDeleted && uc.UserId == userId);
            return APIResponse<ICollection<UserConnection>>.Success("Connections By User If Found", await connections.ToListAsync());
        }
        public async Task<APIResponse<UserConnection>> GetByIdAsync(int id)
        {
            var userConnection=await db.UserConnections.FirstOrDefaultAsync(uc=>!uc.IsDeleted && uc.ConnectionId==id);
            if (userConnection == null)
                return APIResponse<UserConnection>.Failure("User Connection Not Found");
            return APIResponse<UserConnection>.Success("User Connection Found Successfully", userConnection);
        }

        public async Task<APIResponse<UserConnection>> InsertEntity(UserConnection entity)
        {
            await db.UserConnections.AddAsync(entity);
            await db.SaveChangesAsync();
            return APIResponse<UserConnection>.Success("User Connection Inserted Successfully", entity);
        }

        public async Task<APIResponse<UserConnection>> UpdateEntity(UserConnection entity)
        {
            db.UserConnections.Update(entity);
            await db.SaveChangesAsync();
            return APIResponse<UserConnection>.Success("User Connection Updated Successfully", entity);
        }
    }
}
