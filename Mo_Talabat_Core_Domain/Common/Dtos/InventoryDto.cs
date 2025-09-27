namespace Mo_Talabat_Core_Domain.Common.Dtos
{
    public class InventoryDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int CurrentStock { get; set; }
        public int? MinStockLevel { get; set; }
        public bool IsLowStock { get; set; }
        public bool IsOutOfStock { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    public class StockUpdateDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Reason { get; set; } = string.Empty; // Restock, Sale, Return, Adjustment
        public string? Notes { get; set; }
    }

    public class LowStockAlertDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int CurrentStock { get; set; }
        public int MinStockLevel { get; set; }
        public int RecommendedOrder { get; set; }
    }
}
