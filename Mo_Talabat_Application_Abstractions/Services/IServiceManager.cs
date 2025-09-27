using Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfProduct;
using Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfCart;
using Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfOrder;
using Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfUser;
using Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfCoupon;
using Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfReview;
using Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfInventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Services
{
    public  interface IServiceManager
    {
        public IProductServices ProductService { get; }
        public ICartService CartService { get; }
        public IOrderService OrderService { get; }
        public IUserService UserService { get; }
        public ICouponService CouponService { get; }
        public IReviewService ReviewService { get; }
        public IInventoryService InventoryService { get; }
    }
}
