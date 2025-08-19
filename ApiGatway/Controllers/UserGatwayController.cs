using ApiGatway.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resouces.DTOs;
using Resources.DTOs;

namespace ApiGatway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserGatwayController : Controller
    {
        private readonly ILogger<UserGatwayController> _logger;
        private readonly IUserService _userService;

        
        public UserGatwayController(ILogger<UserGatwayController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Login([FromBody] Login loginData)
        {
            string jwt = await _userService.Login(loginData);

            if(!string.IsNullOrEmpty(jwt))
                return Ok(jwt);

            return BadRequest("Usuário ou senha inválidos");
        }

        [HttpPost("CreateAccount")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> CreateAccount([FromBody] UserDto userData)
        {
            bool result = await _userService.CreateAccount(userData);

            if (result)
                return Ok(result);

            return BadRequest();
            
        }
    }
}
