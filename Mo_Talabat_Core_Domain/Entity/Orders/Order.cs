using Mo_Talabat_Core_Domain.Common;
using Mo_Talabat_Core_Domain.Entity.Users;
using System.ComponentModel.DataAnnotations;

namespace Mo_Talabat_Core_Domain.Entity.Orders
{
    public class Order : BaseEntity<int>
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [MaxLength(50)]
        public string OrderNumber { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [MaxLength(20)]
        public string Status { get; set; } = "Pending"; // Pending, Confirmed, Shipped, Delivered, Cancelled

        [MaxLength(20)]
        public string PaymentStatus { get; set; } = "Pending"; // Pending, Paid, Failed, Refunded

        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }

        [MaxLength(200)]
        public string? ShippingAddress { get; set; }

        [MaxLength(200)]
        public string? Notes { get; set; }

        // Navigation Properties
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
