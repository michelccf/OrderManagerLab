using Microsoft.AspNetCore.Mvc;
using Resouces.DTOs;
using Resources.DTOs;

namespace ApiGatway.Controllers
{
    public class UserGatwayController : Controller
    {
        private readonly ILogger<UserGatwayController> _logger;

        public UserGatwayController(ILogger<UserGatwayController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Login/")]
        public async Task<ActionResult<bool>> Login([FromBody] Login loginData)
        {
            //TODO: Deve chamar api de User para Validar a senha e retornar o jwt.
            return false;
        }

        [HttpPost("CreateAccount/")]
        public async Task<ActionResult<bool>> CreateAccount([FromBody] UserDto userData)
        {
            //TODO: Deve chamar api de User para criar o usuario no banco de dados e retornar sucesso ou erro.
            return false;
        }
    }
}
