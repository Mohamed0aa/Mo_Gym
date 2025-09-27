using Microsoft.AspNetCore.Mvc;
using Share;
using Share.Services;
using Mo_Talabat_Core_Domain.Common.Dtos;

namespace Mo_Api_Talabat_Controllers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CouponsController(IServiceManager serviceManager) : BaseApiController
    {
        [HttpGet("{couponId:int}")]
        public async Task<ActionResult<CouponDto>> GetCoupon(int couponId)
        {
            var coupon = await serviceManager.CouponService.GetCouponAsync(couponId);
            return Ok(coupon);
        }

        [HttpGet("code/{code}")]
        public async Task<ActionResult<CouponDto>> GetCouponByCode(string code)
        {
            var coupon = await serviceManager.CouponService.GetCouponByCodeAsync(code);
            return Ok(coupon);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CouponDto>>> GetAllCoupons()
        {
            var coupons = await serviceManager.CouponService.GetAllCouponsAsync();
            return Ok(coupons);
        }

        [HttpPost]
        public async Task<ActionResult<CouponDto>> CreateCoupon([FromBody] CreateCouponDto createCouponDto)
        {
            var coupon = await serviceManager.CouponService.CreateCouponAsync(createCouponDto);
            return Ok(coupon);
        }

        [HttpPut("{couponId:int}")]
        public async Task<ActionResult<CouponDto>> UpdateCoupon(int couponId, [FromBody] CreateCouponDto updateCouponDto)
        {
            var coupon = await serviceManager.CouponService.UpdateCouponAsync(couponId, updateCouponDto);
            return Ok(coupon);
        }

        [HttpDelete("{couponId:int}")]
        public async Task<ActionResult> DeleteCoupon(int couponId)
        {
            var result = await serviceManager.CouponService.DeleteCouponAsync(couponId);
            return result ? Ok() : NotFound();
        }

        [HttpPost("validate")]
        public async Task<ActionResult<CouponValidationResult>> ValidateCoupon([FromBody] ValidateCouponDto validateCouponDto)
        {
            var result = await serviceManager.CouponService.ValidateCouponAsync(validateCouponDto);
            return Ok(result);
        }

        [HttpPost("{couponId:int}/use")]
        public async Task<ActionResult> UseCoupon(int couponId)
        {
            var result = await serviceManager.CouponService.UseCouponAsync(couponId);
            return result ? Ok() : BadRequest();
        }
    }
}
