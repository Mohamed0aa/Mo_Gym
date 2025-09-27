using Mo_Talabat_Core_Domain.Common;
using Mo_Talabat_Core_Domain.Entity.Orders;
using System.ComponentModel.DataAnnotations;

namespace Mo_Talabat_Core_Domain.Entity.Promotions
{
    public class Coupon : BaseEntity<int>
    {
        [MaxLength(50)]
        public string Code { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(20)]
        public string DiscountType { get; set; } = "Percentage"; // Percentage, FixedAmount

        public decimal DiscountValue { get; set; }
        public decimal? MinimumOrderAmount { get; set; }
        public decimal? MaximumDiscountAmount { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int UsageLimit { get; set; } = 1;
        public int UsedCount { get; set; } = 0;

        public bool IsActive { get; set; } = true;

        // Navigation Properties
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
