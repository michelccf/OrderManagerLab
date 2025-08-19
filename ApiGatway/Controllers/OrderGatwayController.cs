using ApiGatway.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resouces.DTOs;
using Resouces.Entities;

namespace ApiGatway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class OrderGatwayController : ControllerBase
    {
        private readonly ILogger<OrderGatwayController> _logger;
        private readonly IOrderService _orderService;

        public OrderGatwayController(ILogger<OrderGatwayController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        } 

        [HttpPost("Order/UserId/{UserId}")]
        public async Task<ActionResult<bool>> Order(long UserId, [FromBody] List<ProductsDto> CartProducts)
        {
            bool result = await _orderService.Order(CartProducts, UserId);
            return result;
        }
    }
}
