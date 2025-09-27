using Microsoft.AspNetCore.Mvc;
using Share;
using Share.Services;
using Mo_Talabat_Core_Domain.Common.Dtos;

namespace Mo_Api_Talabat_Controllers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController(IServiceManager serviceManager) : BaseApiController
    {
        [HttpGet("{userId:int}")]
        public async Task<ActionResult<CartDto>> GetCart(int userId)
        {
            var cart = await serviceManager.CartService.GetCartAsync(userId);
            return Ok(cart);
        }

        [HttpPost("{userId:int}/items")]
        public async Task<ActionResult<CartItemDto>> AddToCart(int userId, [FromBody] AddToCartRequest request)
        {
            var cartItem = await serviceManager.CartService.AddToCartAsync(userId, request.ProductId, request.Quantity);
            return Ok(cartItem);
        }

        [HttpPut("{userId:int}/items/{productId:int}")]
        public async Task<ActionResult<CartItemDto>> UpdateCartItem(int userId, int productId, [FromBody] UpdateCartItemRequest request)
        {
            var cartItem = await serviceManager.CartService.UpdateCartItemAsync(userId, productId, request.Quantity);
            return Ok(cartItem);
        }

        [HttpDelete("{userId:int}/items/{productId:int}")]
        public async Task<ActionResult> RemoveFromCart(int userId, int productId)
        {
            var result = await serviceManager.CartService.RemoveFromCartAsync(userId, productId);
            return result ? Ok() : NotFound();
        }

        [HttpDelete("{userId:int}")]
        public async Task<ActionResult> ClearCart(int userId)
        {
            var result = await serviceManager.CartService.ClearCartAsync(userId);
            return result ? Ok() : NotFound();
        }

        [HttpGet("{userId:int}/count")]
        public async Task<ActionResult<int>> GetCartItemsCount(int userId)
        {
            var count = await serviceManager.CartService.GetCartItemsCountAsync(userId);
            return Ok(count);
        }
    }

    public class AddToCartRequest
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; } = 1;
    }

    public class UpdateCartItemRequest
    {
        public int Quantity { get; set; }
    }
}
