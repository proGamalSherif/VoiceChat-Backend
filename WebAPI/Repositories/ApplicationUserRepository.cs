using Microsoft.EntityFrameworkCore;
using WebAPI.DBContext;
using WebAPI.Entities;
using WebAPI.Interfaces.Repositories;
using WebAPI.Responses;

namespace WebAPI.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly VoiceDBContext db;
        public ApplicationUserRepository(VoiceDBContext _db)
        {
            db= _db;
        }
        public async Task<APIResponse<string>> DeleteEntity(Guid id)
        {
            var userResponse = await GetByIdAsync(id);
            if (!userResponse.IsSuccess || userResponse.Data == null)
                return APIResponse<string>.Failure("User Not Found");
            var user = userResponse.Data;
            user.IsDeleted = true;
            await db.SaveChangesAsync();
            return APIResponse<string>.Success(message: "User Removed Successfully");
        }
        public async Task<APIResponse<ICollection<ApplicationUser>>> GetAllAsync()
        {
            var users = db.Users
                .Where(u => !u.IsDeleted);
            return APIResponse<ICollection<ApplicationUser>>.Success(data: await users.ToListAsync());
        }
        public async Task<APIResponse<ApplicationUser>> GetByIdAsync(Guid id)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => !u.IsDeleted && u.UserId == id);
            if (user == null) return APIResponse<ApplicationUser>.Failure("User Not Found");
            return APIResponse<ApplicationUser>.Success(data: user);
        }
        public async Task<APIResponse<ApplicationUser>> InsertEntity(ApplicationUser user)
        {
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            return APIResponse<ApplicationUser>.Success("User Inserted Successfully", data: user);
        }
        public async Task<APIResponse<ApplicationUser>> UpdateEntity(ApplicationUser user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
            return APIResponse<ApplicationUser>.Success("User Updated Successfully",data: user);
        }
    }
}
