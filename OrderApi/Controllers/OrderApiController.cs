using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resouces.DTOs;

namespace OrderApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class OrderApiController : ControllerBase
    {
        private readonly ILogger<OrderApiController> _logger;

        public OrderApiController(ILogger<OrderApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Order/UserId/{UserId}")]
        public async Task<ActionResult<bool>> Order(long UserId, [FromBody]List<ProductsDto> CartProducts)
        {
            return false;
        }
    }
}
