using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopVerse.Services.CouponAPI.Data;
using ShopVerse.Services.CouponAPI.Models;
using ShopVerse.Services.CouponAPI.Models.DTOs;

namespace ShopVerse.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    [Authorize]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        private readonly ResponseDTO _responseDTO;
        private IMapper _mapper;

        public CouponAPIController(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            _mapper = mapper;
            _responseDTO = new ResponseDTO();
        }

        [HttpGet]
        public ResponseDTO GetCoupons()
        {
            var copupons = appDbContext.Coupons.ToList();            
            _responseDTO.Result = _mapper.Map<List<CouponDTO>>(copupons); 
            return _responseDTO;
        }

        [HttpGet("{id}")]
        public ResponseDTO GetCouponById(int id)
        {
            var coupon = appDbContext.Coupons.FirstOrDefault(c => c.Id == id);
            
            if (coupon == null)
            {
                _responseDTO.IsSuccess = false;

            }
            _responseDTO.Result = _mapper.Map<CouponDTO>(coupon); 
            return _responseDTO;
        }

        [HttpGet("GetCouponByCode/{code}")]
        public ResponseDTO GetCouponByCode(string code)
        {
            var coupon = appDbContext.Coupons.FirstOrDefault(c => c.CouponCode == code);            
            if (coupon == null)
            {
                _responseDTO.IsSuccess = false;

            }
            _responseDTO.Result = _mapper.Map<CouponDTO>(coupon); 
            return _responseDTO;
        }

        [HttpPost]
        public ResponseDTO CreateCoupon([FromBody] CouponDTO couponDTO)
        {
            var coupon = _mapper.Map<Coupon>(couponDTO);
            appDbContext.Coupons.Add(coupon);
            appDbContext.SaveChanges();
            _responseDTO.Result = _mapper.Map<CouponDTO>(coupon);
            return _responseDTO;
        }

        [HttpPut]
        public IActionResult UpdateCoupon(string id, [FromBody] CouponDTO couponDTO)
        {
            // Get the existing coupon from the database using the provided id
            var existingCoupon = appDbContext.Coupons.FirstOrDefault(c => c.Id == int.Parse(id));

            if (existingCoupon == null)
            {
                return NotFound();
            }

            // Map the updated properties from the DTO to the existing coupon entity
            existingCoupon.CouponCode = couponDTO.CouponCode;
            existingCoupon.DiscountAmount = couponDTO.DiscountAmount;
            existingCoupon.MinAmount = couponDTO.MinAmount;

            appDbContext.Coupons.Update(existingCoupon);
            appDbContext.SaveChanges();
            return NoContent();
        }

    }
}
