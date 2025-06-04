using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs.RoomChat;
using WebAPI.Interfaces.Services;
namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomChatController : ControllerBase
    {
        private readonly IRoomChatService roomChatService;
        public RoomChatController(IRoomChatService _roomChatService)
        {
            roomChatService = _roomChatService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await roomChatService.GetAllAsync();
            if (!result.IsSuccess || result.Data == null)
                return NotFound(result.Message);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await roomChatService.GetByIdAsync(id);
            if (!result.IsSuccess || result.Data == null)
                return NotFound(result.Message);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> InsertEntity([FromForm]InsertRoomChatDTO entityDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await roomChatService.InsertEntity(entityDTO);
            if (!result.IsSuccess || result.Data == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEntity(UpdateRoomChatDTO entityDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await roomChatService.UpdateEntity(entityDTO);
            if (!result.IsSuccess || result.Data == null)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(int id)
        {
            var result = await roomChatService.DeleteEntity(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
