using Microsoft.AspNetCore.Mvc;
using Share;
using Share.Services;
using Mo_Talabat_Core_Domain.Common.Dtos;

namespace Mo_Api_Talabat_Controllers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController(IServiceManager serviceManager) : BaseApiController
    {
        [HttpGet("product/{productId:int}")]
        public async Task<ActionResult<InventoryDto>> GetProductInventory(int productId)
        {
            var inventory = await serviceManager.InventoryService.GetProductInventoryAsync(productId);
            return Ok(inventory);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryDto>>> GetAllInventory()
        {
            var inventory = await serviceManager.InventoryService.GetAllInventoryAsync();
            return Ok(inventory);
        }

        [HttpPut("stock")]
        public async Task<ActionResult> UpdateStock([FromBody] StockUpdateDto stockUpdateDto)
        {
            var result = await serviceManager.InventoryService.UpdateStockAsync(stockUpdateDto);
            return result ? Ok() : BadRequest();
        }

        [HttpPost("restock/{productId:int}")]
        public async Task<ActionResult> RestockProduct(int productId, [FromBody] RestockRequest request)
        {
            var result = await serviceManager.InventoryService.RestockProductAsync(productId, request.Quantity, request.Notes);
            return result ? Ok() : BadRequest();
        }

        [HttpPost("reduce/{productId:int}")]
        public async Task<ActionResult> ReduceStock(int productId, [FromBody] ReduceStockRequest request)
        {
            var result = await serviceManager.InventoryService.ReduceStockAsync(productId, request.Quantity, request.Reason);
            return result ? Ok() : BadRequest();
        }

        [HttpGet("low-stock")]
        public async Task<ActionResult<IEnumerable<LowStockAlertDto>>> GetLowStockAlerts()
        {
            var alerts = await serviceManager.InventoryService.GetLowStockAlertsAsync();
            return Ok(alerts);
        }

        [HttpPut("min-level/{productId:int}")]
        public async Task<ActionResult> SetMinStockLevel(int productId, [FromBody] SetMinLevelRequest request)
        {
            var result = await serviceManager.InventoryService.SetMinStockLevelAsync(productId, request.MinLevel);
            return result ? Ok() : BadRequest();
        }

        [HttpGet("check/{productId:int}")]
        public async Task<ActionResult<bool>> IsProductInStock(int productId, [FromQuery] int quantity = 1)
        {
            var isInStock = await serviceManager.InventoryService.IsProductInStockAsync(productId, quantity);
            return Ok(isInStock);
        }

        [HttpGet("available/{productId:int}")]
        public async Task<ActionResult<int>> GetAvailableStock(int productId)
        {
            var stock = await serviceManager.InventoryService.GetAvailableStockAsync(productId);
            return Ok(stock);
        }
    }

    public class RestockRequest
    {
        public int Quantity { get; set; }
        public string? Notes { get; set; }
    }

    public class ReduceStockRequest
    {
        public int Quantity { get; set; }
        public string Reason { get; set; } = "Sale";
    }

    public class SetMinLevelRequest
    {
        public int MinLevel { get; set; }
    }
}
