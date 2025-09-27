using Microsoft.AspNetCore.Mvc;
using Share;
using Share.Services;
using Mo_Talabat_Core_Domain.Common.Dtos;

namespace Mo_Api_Talabat_Controllers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController(IServiceManager serviceManager) : BaseApiController
    {
        [HttpPost("{userId:int}")]
        public async Task<ActionResult<OrderDto>> CreateOrder(int userId, [FromBody] CreateOrderDto createOrderDto)
        {
            var order = await serviceManager.OrderService.CreateOrderAsync(userId, createOrderDto);
            return Ok(order);
        }

        [HttpGet("{orderId:int}")]
        public async Task<ActionResult<OrderDto>> GetOrder(int orderId)
        {
            var order = await serviceManager.OrderService.GetOrderAsync(orderId);
            return Ok(order);
        }

        [HttpGet("user/{userId:int}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetUserOrders(int userId)
        {
            var orders = await serviceManager.OrderService.GetUserOrdersAsync(userId);
            return Ok(orders);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders()
        {
            var orders = await serviceManager.OrderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpPut("{orderId:int}/status")]
        public async Task<ActionResult<OrderDto>> UpdateOrderStatus(int orderId, [FromBody] UpdateOrderStatusRequest request)
        {
            var order = await serviceManager.OrderService.UpdateOrderStatusAsync(orderId, request.Status);
            return Ok(order);
        }

        [HttpPut("{orderId:int}/cancel")]
        public async Task<ActionResult> CancelOrder(int orderId)
        {
            var result = await serviceManager.OrderService.CancelOrderAsync(orderId);
            return result ? Ok() : NotFound();
        }
    }

    public class UpdateOrderStatusRequest
    {
        public string Status { get; set; } = string.Empty;
    }
}
