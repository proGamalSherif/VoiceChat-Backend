using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs.Room;
using WebAPI.Interfaces.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;
        public RoomController(IRoomService _roomService)
        {
            roomService = _roomService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await roomService.GetAllAsync();
            if (!result.IsSuccess || result.Data == null)
                return NotFound(result.Message);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await roomService.GetByIdAsync(id);
            if (!result.IsSuccess || result.Data == null)
                return NotFound(result.Message);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> InsertEntity([FromForm]InsertRoomDTO entityDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await roomService.InsertEntity(entityDTO);
            if (!result.IsSuccess || result.Data == null)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpPost("InsertRoomWithUser/{userId}")]
        public async Task<IActionResult> InsertEntityWithUser(Guid userId, [FromForm]InsertRoomDTO entityDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result  = await roomService.InsertEntityWithUser(userId, entityDTO);
            if (!result.IsSuccess || result.Data == null)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEntity(UpdateRoomDTO entityDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await roomService.UpdateEntity(entityDTO);
            if (!result.IsSuccess || result.Data == null)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(int id)
        {
            var result = await roomService.DeleteEntity(id);
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
