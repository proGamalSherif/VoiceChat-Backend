using Microsoft.EntityFrameworkCore;
using WebAPI.DBContext;
using WebAPI.Entities;
using WebAPI.Interfaces.Repositories;
using WebAPI.Responses;

namespace WebAPI.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly VoiceDBContext db;
        public RoomRepository(VoiceDBContext _db)
        {
            db = _db;
        }
        public async Task<APIResponse<string>> DeleteEntity(int id)
        {
            var roomResponse = await GetByIdAsync(id);
            if (!roomResponse.IsSuccess || roomResponse.Data == null)
                return APIResponse<string>.Failure("Room Not Found");
            var room = roomResponse.Data;
            room.IsDeleted = true;
            await db.SaveChangesAsync();
            return APIResponse<string>.Success("Room Deleted Successfull");
        }

        public async Task<APIResponse<ICollection<Room>>> GetAllAsync()
        {
            var allRooms = await db.Rooms
                .Include(rc => rc.RoomChats)
                    .ThenInclude(u => u.User)
                .Where(r => !r.IsDeleted)
                .ToListAsync();

            if (!allRooms.Any() || allRooms.Count == 0 )
                return APIResponse<ICollection<Room>>.Failure("No Rooms Found");

            return APIResponse<ICollection<Room>>.Success("Rooms Found Successfully", allRooms);
        }
        public async Task<APIResponse<Room>> GetByIdAsync(int id)
        {
            var room = await db.Rooms
                .Include(rc => rc.RoomChats)
                    .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(r=>!r.IsDeleted && r.RoomId==id);
            if (room == null)
                return APIResponse<Room>.Failure("No Room Found");
            return APIResponse<Room>.Success("Room Found Successfully", room);
        }

        public async Task<APIResponse<Room>> InsertEntity(Room entity)
        {
            await db.AddAsync(entity);
            await db.SaveChangesAsync();
            return APIResponse<Room>.Success("Room Inserted Successfully", entity);
        }
        public async Task<APIResponse<Room>> UpdateEntity(Room entity)
        {
            db.Rooms.Update(entity);
            await db.SaveChangesAsync();
            return APIResponse<Room>.Success("Room Updated Successfully", entity);
        }
    }
}
