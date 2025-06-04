using WebAPI.Entities;
using WebAPI.Responses;

namespace WebAPI.Interfaces.Repositories
{
    public interface IVoiceCallingRepository
    {
        Task<APIResponse<ICollection<VoiceCalling>>> GetAllAsync();
        Task<APIResponse<VoiceCalling>> GetByIdAsync(int id);
        Task<APIResponse<VoiceCalling>> InsertEntity(VoiceCalling entity);
        Task<APIResponse<VoiceCalling>> UpdateEntity(VoiceCalling entity);
        Task<APIResponse<string>> DeleteEntity(int id);
    }
}
