using Microsoft.EntityFrameworkCore;
using WebAPI.DBContext;
using WebAPI.Entities;
using WebAPI.Interfaces.Repositories;
using WebAPI.Responses;

namespace WebAPI.Repositories
{
    public class VoiceCallingRepository : IVoiceCallingRepository
    {
        private readonly VoiceDBContext db;
        public VoiceCallingRepository(VoiceDBContext _db)
        {
            db = _db;
        }
        public async Task<APIResponse<string>> DeleteEntity(int id)
        {
            var response = await GetByIdAsync(id);
            if (!response.IsSuccess || response.Data == null)
                return APIResponse<string>.Failure(response.Message);
            var voiceCalling = response.Data;
            voiceCalling.IsDeleted = true;
            return APIResponse<string>.Success("User Calling Deleted Successfully");
        }

        public async Task<APIResponse<ICollection<VoiceCalling>>> GetAllAsync()
        {
            var voiceCallings = await db.VoiceCallings
                .Where(vc => !vc.IsDeleted).ToListAsync();
            if (voiceCallings.Count == 0)
                return APIResponse<ICollection<VoiceCalling>>.Failure("No Voice Calling Found");
            return APIResponse<ICollection<VoiceCalling>>.Success("Voice Callings Found Successfully", voiceCallings);
        }

        public async Task<APIResponse<VoiceCalling>> GetByIdAsync(int id)
        {
            var voiceCalling = await db.VoiceCallings.FirstOrDefaultAsync(vc => !vc.IsDeleted && vc.VoiceCallingId == id);
            if (voiceCalling == null)
                return APIResponse<VoiceCalling>.Failure("No Voice Calling Found");
            return APIResponse<VoiceCalling>.Success("Voice Calling Found Successfully", voiceCalling);
        }

        public async Task<APIResponse<VoiceCalling>> InsertEntity(VoiceCalling entity)
        {
            await db.VoiceCallings.AddAsync(entity);
            await db.SaveChangesAsync();
            return APIResponse<VoiceCalling>.Success("Voice Calling Inserted Successfully", entity);
        }

        public async Task<APIResponse<VoiceCalling>> UpdateEntity(VoiceCalling entity)
        {
            db.VoiceCallings.Update(entity);
            await db.SaveChangesAsync();
            return APIResponse<VoiceCalling>.Success("Voice Calling Inserted Successfully", entity);
        }
    }
}
