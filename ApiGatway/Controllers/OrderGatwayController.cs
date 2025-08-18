using Microsoft.AspNetCore.Mvc;

namespace ApiGatway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderGatwayController : ControllerBase
    {
        private readonly ILogger<OrderGatwayController> _logger;

        public OrderGatwayController(ILogger<OrderGatwayController> logger)
        {
            _logger = logger;
        } 

        [HttpPost("Order/")]
        public async Task<ActionResult<bool>> Order()
        {
            //TODO: Serviço de pedidos deve chamar Api de Order para Salvar dados do pedido no banco.
            return null;
        }
    }
}
