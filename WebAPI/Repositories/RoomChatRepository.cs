using Microsoft.EntityFrameworkCore;
using WebAPI.DBContext;
using WebAPI.Entities;
using WebAPI.Interfaces.Repositories;
using WebAPI.Responses;

namespace WebAPI.Repositories
{
    public class RoomChatRepository : IRoomChatRepository
    {
        private readonly VoiceDBContext db;
        public RoomChatRepository(VoiceDBContext _db)
        {
            db = _db;
        }
        public async Task<APIResponse<string>> DeleteEntity(int id)
        {
            var userResponse = await GetByIdAsync(id);
            if (!userResponse.IsSuccess || userResponse.Data == null) return APIResponse<string>.Failure("Room Chat Not Found");

            var roomChat = userResponse.Data;
            roomChat.IsDeleted = true;
            await db.SaveChangesAsync();
            return APIResponse<string>.Success("Room Chat Deleted Successfully");
        }
        public async Task<APIResponse<ICollection<RoomChat>>> GetAllAsync()
        {
            var roomChats = db.RoomChats
                .Include(r=>r.Room)
                .Include(u=>u.User)
                .Where(rc => !rc.IsDeleted);
            if (!await roomChats.AnyAsync()) return APIResponse<ICollection<RoomChat>>.Failure("No Room Chats Found");
            return APIResponse<ICollection<RoomChat>>.Success(message: "Room Chat Found Successfully", data: await roomChats.ToListAsync());
        }
        public async Task<APIResponse<RoomChat>> GetByIdAsync(int id)
        {
            var roomChat = await db.RoomChats
                .Include(r => r.Room)
                .Include(u => u.User)
                .FirstOrDefaultAsync(rc => !rc.IsDeleted && rc.RoomId==id);
            if (roomChat == null) return APIResponse<RoomChat>.Failure("Room Chat Not Found");
            return APIResponse<RoomChat>.Success("Room Chat Found Successfully", roomChat);
        }
        public async Task<APIResponse<ICollection<RoomChat>>> GetByRoomId(int id)
        {
            var roomChats = await db.RoomChats
                .Include(r => r.Room)
                .Include(u => u.User)
                .Where(rc => rc.RoomId == id).ToListAsync();
            return APIResponse<ICollection<RoomChat>>.Success(message: "Room Chat Found Successfully", data: roomChats);
        }
        public async Task<APIResponse<RoomChat>> InsertEntity(RoomChat entity)
        {
            await db.RoomChats.AddAsync(entity);
            await db.SaveChangesAsync();
            return APIResponse<RoomChat>.Success("Room Chat Inserted Successfully", entity);
        }
        public async Task<APIResponse<RoomChat>> UpdateEntity(RoomChat entity)
        {
            db.RoomChats.Update(entity);
            await db.SaveChangesAsync();
            return APIResponse<RoomChat>.Success("Room Chat Updated Successfully", entity);
        }
    }
}
