using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs.ApplicationUser;
using WebAPI.Interfaces.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUserService applicationUserService;
        public ApplicationUserController(IApplicationUserService _applicationUserService)
        {
            applicationUserService = _applicationUserService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await applicationUserService.GetAllAsync();
            if(!result.IsSuccess || result.Data == null)
                return NotFound(result.Message);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await applicationUserService.GetByIdAsync(id);
            if (!result.IsSuccess || result.Data == null)
                return NotFound(result.Message);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> InsertEntity([FromForm]InsertApplicationUserDTO entityDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await applicationUserService.InsertEntity(entityDTO);
            if (!result.IsSuccess || result.Data == null)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEntity(UpdateApplicationUserDTO entityDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await applicationUserService.UpdateEntity(entityDTO);
            if (!result.IsSuccess || result.Data == null)
                return BadRequest(result.Message);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(Guid id)
        {
            var result = await applicationUserService.DeleteEntity(id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
