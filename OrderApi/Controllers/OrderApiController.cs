using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderApi.Interfaces.Services;
using Resouces.DTOs;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderApiController : ControllerBase
    {
        private readonly ILogger<OrderApiController> _logger;
        private readonly IOrderService _orderService;

        public OrderApiController(ILogger<OrderApiController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpPost("Order/UserId/{UserId}")]
        public async Task<ActionResult<bool>> Order(long UserId, [FromBody]List<ProductsDto> CartProducts)
        {
            bool result = await _orderService.Order(UserId, CartProducts);
            
            if(result)
               return Ok(result);

            return BadRequest("Erro na criação do pedido");
        }
    }
}
