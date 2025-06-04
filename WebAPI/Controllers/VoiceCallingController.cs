using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs.VoiceCalling;
using WebAPI.Interfaces.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoiceCallingController : ControllerBase
    {
        private readonly IVoiceCallingService voiceCallingService;
        public VoiceCallingController(IVoiceCallingService _voiceCallingService)
        {
            voiceCallingService = _voiceCallingService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await voiceCallingService.GetAllAsync();
            if (!result.IsSuccess || result.Data == null)
                return NotFound(result.Message);
            return Ok(result);  
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await voiceCallingService.GetByIdAsync(id);
            if (!result.IsSuccess || result.Data == null)
                return NotFound(result.Message);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> InsertEntity(InsertVoiceCallingDTO entityDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await voiceCallingService.InsertEntity(entityDTO);
            if(!result.IsSuccess || result.Data == null)
                return NotFound(result.Message);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEntity(UpdateVoiceCallingDTO entityDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await voiceCallingService.UpdateEntity(entityDTO);
            if (!result.IsSuccess || result.Data == null)
                return NotFound(result.Message);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(int id)
        {
            var result = await voiceCallingService.DeleteEntity(id);
            if (!result.IsSuccess)
                return NotFound(result.Message);
            return Ok(result);
        }
    }
}
