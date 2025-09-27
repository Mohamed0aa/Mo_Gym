using Mo_Talabat_Core_Domain.Common;
using Mo_Talabat_Core_Domain.Entity.Orders;
using Mo_Talabat_Core_Domain.Entity.Reviews;
using System.ComponentModel.DataAnnotations;

namespace Mo_Talabat_Core_Domain.Entity.Users
{
    public class User : BaseEntity<int>
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(200)]
        public string? ProfilePictureUrl { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(10)]
        public string? Gender { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        public bool IsActive { get; set; } = true;
        public bool IsEmailVerified { get; set; } = false;
        public bool IsPhoneVerified { get; set; } = false;
        public DateTime? LastLoginDate { get; set; }

        // Navigation Properties
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
    }
}
