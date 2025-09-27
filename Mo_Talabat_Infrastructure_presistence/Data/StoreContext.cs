using Microsoft.EntityFrameworkCore;
using Mo_Talabat_Core_Domain.Entity.Products;
using Mo_Talabat_Core_Domain.Entity.Users;
using Mo_Talabat_Core_Domain.Entity.Orders;
using Mo_Talabat_Core_Domain.Entity.Promotions;
using Mo_Talabat_Core_Domain.Entity.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mo_Talabat_Infrastructure_presistence.Data
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyInfo).Assembly);
        }
        
        // Products
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> Brands { get; set; }
        public DbSet<ProductCatrgory> Categories { get; set; }
        
        // Users
        public DbSet<User> Users { get; set; }
        
        // Orders
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        
        // Promotions
        public DbSet<Coupon> Coupons { get; set; }
        
        // Reviews
        public DbSet<ProductReview> ProductReviews { get; set; }
    }
}
