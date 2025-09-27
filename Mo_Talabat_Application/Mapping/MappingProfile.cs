using AutoMapper;
using Mo_Talabat_Core_Domain.Common.Dtos;
using Mo_Talabat_Core_Domain.Entity.Products;
using Mo_Talabat_Core_Domain.Entity.Users;
using Mo_Talabat_Core_Domain.Entity.Orders;
using Mo_Talabat_Core_Domain.Entity.Reviews;
using Mo_Talabat_Core_Domain.Entity.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Mapping
{
    internal class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Products
            CreateMap<Product, ProductReturnDto>()
                .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand!.Name))
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category!.Name))
                .ForMember(d => d.PictureUrl,  o => o.MapFrom<PictureResolver>());
            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductCatrgory,CategoryDto>();

            // Users
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Cart
            CreateMap<CartItem, CartItemDto>()
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product.Name))
                .ForMember(d => d.ProductPictureUrl, o => o.MapFrom(s => s.Product.PictureUrl));

            // Orders
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product.Name))
                .ForMember(d => d.ProductPictureUrl, o => o.MapFrom(s => s.Product.PictureUrl));

            // Reviews
            CreateMap<ProductReview, ProductReviewDto>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => $"{s.User.FirstName} {s.User.LastName}"));

            // Coupons
            CreateMap<Coupon, CouponDto>();
            CreateMap<CreateCouponDto, Coupon>();

            // Inventory
            CreateMap<Product, InventoryDto>()
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Name))
                .ForMember(d => d.CurrentStock, o => o.MapFrom(s => s.StockQuantity))
                .ForMember(d => d.IsLowStock, o => o.MapFrom(s => s.StockQuantity <= (s.MinStockLevel ?? 0)))
                .ForMember(d => d.IsOutOfStock, o => o.MapFrom(s => s.StockQuantity <= 0))
                .ForMember(d => d.LastUpdated, o => o.MapFrom(s => s.LastModifiedOn));
        }
    }
}
