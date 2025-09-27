using Mo_Talabat_Core_Domain.Common;
using Mo_Talabat_Core_Domain.Entity.Products;
using Mo_Talabat_Core_Domain.Entity.Users;
using System.ComponentModel.DataAnnotations;

namespace Mo_Talabat_Core_Domain.Entity.Reviews
{
    public class ProductReview : BaseEntity<int>
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int Rating { get; set; } // 1-5 stars

        [MaxLength(500)]
        public string? Comment { get; set; }

        public bool IsVerified { get; set; } = false; // Verified purchase
        public bool IsApproved { get; set; } = true; // Admin approval

        public DateTime ReviewDate { get; set; } = DateTime.UtcNow;
    }
}
