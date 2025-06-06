using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs.UserStatus;
using WebAPI.Interfaces.Services;
using WebAPI.Responses;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStatusController : ControllerBase
    {
        private readonly IUserStatusService userStatusService;
        public UserStatusController(IUserStatusService _userStatusService)
        {
            userStatusService = _userStatusService;
        }
        [HttpGet("{userId}/{roomId}")]
        public async Task<IActionResult> GetUserStatus(Guid userId,int roomId)
        {
            var result = await userStatusService.GetUserStatus(userId,roomId);
            if (!result.IsSuccess)
                return NotFound(result);
            return Ok(result);
        }
        [HttpGet("{roomId}")]
        public async Task<IActionResult> GetAllUsersByRoomId(int roomId)
        {
            var result = await userStatusService.GetAllUsersOnlineInRoom(roomId);
            if (!result.IsSuccess)
                return NotFound(result);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> SetUserStatus([FromForm] InsertUserStatusDTO entityDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await userStatusService.SetUserStatus(entityDTO);
            if(!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("LogoutUser/{userId}")]
        public async Task<IActionResult> LogoutUser(Guid userId)
        {
            await userStatusService.LogoutUser(userId);
            return Ok();
        }
    }
}
