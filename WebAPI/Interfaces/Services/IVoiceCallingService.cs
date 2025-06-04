using WebAPI.DTOs.VoiceCalling;
using WebAPI.Responses;

namespace WebAPI.Interfaces.Services
{
    public interface IVoiceCallingService
    {
        Task<APIResponse<ICollection<ReadVoiceCallingDTO>>> GetAllAsync();
        Task<APIResponse<ReadVoiceCallingDTO>> GetByIdAsync(int id);
        Task<APIResponse<ReadVoiceCallingDTO>> InsertEntity(InsertVoiceCallingDTO entitiy);
        Task<APIResponse<ReadVoiceCallingDTO>> UpdateEntity(UpdateVoiceCallingDTO entitiy);
        Task<APIResponse<string>> DeleteEntity(int id);
    }
}
