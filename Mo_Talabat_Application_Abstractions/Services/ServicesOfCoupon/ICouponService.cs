using Mo_Talabat_Core_Domain.Common.Dtos;

namespace Mo_Talabat_Core_Application_Abstractions.Services.ServicesOfCoupon
{
    public interface ICouponService
    {
        Task<CouponDto> GetCouponAsync(int couponId);
        Task<CouponDto> GetCouponByCodeAsync(string code);
        Task<IEnumerable<CouponDto>> GetAllCouponsAsync();
        Task<CouponDto> CreateCouponAsync(CreateCouponDto createCouponDto);
        Task<CouponDto> UpdateCouponAsync(int couponId, CreateCouponDto updateCouponDto);
        Task<bool> DeleteCouponAsync(int couponId);
        Task<CouponValidationResult> ValidateCouponAsync(ValidateCouponDto validateCouponDto);
        Task<bool> UseCouponAsync(int couponId);
    }
}
