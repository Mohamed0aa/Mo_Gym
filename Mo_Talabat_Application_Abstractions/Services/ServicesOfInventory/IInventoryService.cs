using Mo_Talabat_Core_Domain.Common.Dtos;

namespace Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfInventory
{
    public interface IInventoryService
    {
        Task<InventoryDto> GetProductInventoryAsync(int productId);
        Task<IEnumerable<InventoryDto>> GetAllInventoryAsync();
        Task<bool> UpdateStockAsync(StockUpdateDto stockUpdateDto);
        Task<bool> RestockProductAsync(int productId, int quantity, string? notes = null);
        Task<bool> ReduceStockAsync(int productId, int quantity, string reason = "Sale");
        Task<IEnumerable<LowStockAlertDto>> GetLowStockAlertsAsync();
        Task<bool> SetMinStockLevelAsync(int productId, int minLevel);
        Task<bool> IsProductInStockAsync(int productId, int quantity);
        Task<int> GetAvailableStockAsync(int productId);
    }
}
