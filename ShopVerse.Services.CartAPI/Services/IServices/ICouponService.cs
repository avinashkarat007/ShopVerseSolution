using ShopVerse.Services.CartAPI.Models.Dto;

namespace ShopVerse.Services.CartAPI.Services.IServices
{
    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
