using ShopVerse.Web.Models;
using ShopVerse.Web.Service.IService;
using ShopVerse.Web.Utility;

namespace ShopVerse.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto> CreateCoupnAsync(CouponDto couponDTO)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = couponDTO,
                Url = SD.CouponAPIBase + "/api/coupon/ " 
            });
        }

        public async Task<ResponseDto> GetAllCoupons()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon"
            });
        }

        public async Task<ResponseDto> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponAPIBase + "/api/coupon/ "+ id
            });
        }
    }
}
