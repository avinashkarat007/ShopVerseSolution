using AutoMapper;
using ShopVerse.Services.CouponAPI.Models;
using ShopVerse.Services.CouponAPI.Models.DTOs;

namespace ShopVerse.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.CreateMap<Coupon, CouponDTO>();
                mc.CreateMap<CouponDTO, Coupon>();
            });
            return mappingConfig;
        }
    }
}
