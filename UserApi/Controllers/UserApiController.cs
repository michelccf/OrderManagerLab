using Microsoft.AspNetCore.Mvc;
using Resources.DTOs;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserApiController : ControllerBase
    {
        private readonly ILogger<UserApiController> _logger;

        public UserApiController(ILogger<UserApiController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login([FromBody]Login login)
        {

            return null;
        }
    }
}
