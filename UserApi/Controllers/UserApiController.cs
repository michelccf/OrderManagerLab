using Microsoft.AspNetCore.Mvc;
using Resouces.DTOs;
using Resources.DTOs;
using UserApi.Interfaces.Services;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserApiController> _logger;

        public UserApiController(ILogger<UserApiController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login([FromBody]Login login)
        {
            UserDto result = await _userService.Login(login);
            if(result != null)
                return Ok(result);

            return BadRequest();
            
        }

        [HttpPost("CreateAccount")]
        public async Task<ActionResult<bool>> CreateAccount([FromBody] UserDto user)
        {
            bool result = await _userService.CreateAccount(user);
            return result;
        }
    }
}
