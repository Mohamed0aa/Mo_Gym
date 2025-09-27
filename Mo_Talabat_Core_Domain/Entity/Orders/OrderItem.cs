using Mo_Talabat_Core_Domain.Common;
using Mo_Talabat_Core_Domain.Entity.Products;

namespace Mo_Talabat_Core_Domain.Entity.Orders
{
    public class OrderItem : BaseEntity<int>
    {
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
