using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs.UserConnection;
using WebAPI.Interfaces.Services;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserConnectionController : ControllerBase
    {
        private readonly IUserConnectionService userConnectionService;
        public UserConnectionController(IUserConnectionService _userConnectionService)
        {
            userConnectionService = _userConnectionService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await userConnectionService.GetAllAsync();
            if(!result.IsSuccess || result.Data == null)
                return NotFound(result.Message);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await userConnectionService.GetByIdAsync(id);
            if (!result.IsSuccess || result.Data == null)
                return NotFound(result.Message);
            return Ok(result);
        }
        [HttpGet("GetByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(Guid userId)
        {
            var result = await userConnectionService.GetAllByUserId(userId);
            if (!result.IsSuccess || result.Data == null)
                return NotFound(result.Message);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> InsertEntity([FromForm]InsertUserConnectionDTO entityDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await userConnectionService.InsertEntity(entityDTO);
            if (!result.IsSuccess || result.Data == null)
                return BadRequest(result.Message);
            return Ok (result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEntity(UpdateUserConnectionDTO entityDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await userConnectionService.UpdateEntity(entityDTO);
            if (!result.IsSuccess || result.Data == null)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(int id)
        {
            var result = await userConnectionService.DeleteEntity(id);
            if (!result.IsSuccess || result.Data == null)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
