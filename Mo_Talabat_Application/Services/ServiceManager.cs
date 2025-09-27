using AutoMapper;
using Share.Services;
using Mo_Talabat_Core_Domain.Contract;
using Mo_Talabat_Infrastructure_presistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfProduct;
using Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfCart;
using Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfOrder;
using Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfUser;
using Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfCoupon;
using Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfReview;
using Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfInventory;
using Mo_Talabat_Core_Application.Services.ProductServices;
using Mo_Talabat_Core_Application.Services.CartServices;
using Mo_Talabat_Core_Application.Services.OrderServices;
using Mo_Talabat_Core_Application.Services.UserServices;
using Mo_Talabat_Core_Application.Services.CouponServices;
using Mo_Talabat_Core_Application.Services.ReviewServices;
using Mo_Talabat_Core_Application.Services.InventoryServices;

namespace Mo_Talabat_Core_Application.Services
{
    internal class ServiceManager : IServiceManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Lazy<IProductServices> _productServices;
        private readonly Lazy<ICartService> _cartService;
        private readonly Lazy<IOrderService> _orderService;
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<ICouponService> _couponService;
        private readonly Lazy<IReviewService> _reviewService;
        private readonly Lazy<IInventoryService> _inventoryService;

        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productServices = new Lazy<IProductServices>(() => new ProductServices.ProductServices(_unitOfWork, _mapper));
            _cartService = new Lazy<ICartService>(() => new CartServices.CartService(_unitOfWork, _mapper));
            _orderService = new Lazy<IOrderService>(() => new OrderServices.OrderService(_unitOfWork, _mapper));
            _userService = new Lazy<IUserService>(() => new UserServices.UserService(_unitOfWork, _mapper));
            _couponService = new Lazy<ICouponService>(() => new CouponServices.CouponService(_unitOfWork, _mapper));
            _reviewService = new Lazy<IReviewService>(() => new ReviewServices.ReviewService(_unitOfWork, _mapper));
            _inventoryService = new Lazy<IInventoryService>(() => new InventoryServices.InventoryService(_unitOfWork, _mapper));
        }
        
        public IProductServices ProductService => _productServices.Value;
        public ICartService CartService => _cartService.Value;
        public IOrderService OrderService => _orderService.Value;
        public IUserService UserService => _userService.Value;
        public ICouponService CouponService => _couponService.Value;
        public IReviewService ReviewService => _reviewService.Value;
        public IInventoryService InventoryService => _inventoryService.Value;
    }
}
