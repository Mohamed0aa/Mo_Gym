using Mo_Talabat_Core_Domain.Common;
using Mo_Talabat_Core_Domain.Entity.Orders;
using Mo_Talabat_Core_Domain.Entity.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mo_Talabat_Core_Domain.Entity.Products
{
    public class Product: BaseEntity<int>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public  string? PictureUrl { get; set; }
        public required decimal Price { get; set; }
        public decimal? SalePrice { get; set; } // Sale price if on discount
        public int StockQuantity { get; set; } = 0;
        public int? MinStockLevel { get; set; } // Alert when stock is low
        public bool IsActive { get; set; } = true;
        public bool IsOnSale { get; set; } = false;

        public int? BrandId {  get; set; }//forignkey
        public ProductBrand? Brand { get; set; }
        public int? CategoryId { get; set; } //forignkey
        public ProductCatrgory? Category { get; set; }

        // Navigation Properties
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
    }
}
