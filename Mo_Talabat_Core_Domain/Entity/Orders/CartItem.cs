using Mo_Talabat_Core_Domain.Common;
using Mo_Talabat_Core_Domain.Entity.Products;
using Mo_Talabat_Core_Domain.Entity.Users;

namespace Mo_Talabat_Core_Domain.Entity.Orders
{
    public class CartItem : BaseEntity<int>
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int Quantity { get; set; } = 1;
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
