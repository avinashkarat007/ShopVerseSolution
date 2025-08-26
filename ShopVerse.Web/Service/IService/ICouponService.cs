using ShopVerse.Web.Models;

namespace ShopVerse.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto> GetCouponByIdAsync(int id);

        Task<ResponseDto> GetAllCoupons();

        Task<ResponseDto> CreateCoupnAsync(CouponDto couponDTO);

    }
}
