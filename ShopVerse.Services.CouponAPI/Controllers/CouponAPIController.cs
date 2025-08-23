using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopVerse.Services.CouponAPI.Data;
using ShopVerse.Services.CouponAPI.Models;
using ShopVerse.Services.CouponAPI.Models.DTOs;

namespace ShopVerse.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        private IMapper _mapper;

        public CouponAPIController(AppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCoupons()
        {
            var copupons = appDbContext.Coupons.ToList();
            _mapper.Map<List<CouponDTO>>(copupons);
            return Ok(copupons);
        }

        [HttpGet("{id}")]
        public IActionResult GetCouponById(int id)
        {
            var coupon = appDbContext.Coupons.FirstOrDefault(c => c.Id == id);
            _mapper.Map<CouponDTO>(coupon);
            if (coupon == null)
            {
                return NotFound();
            }
            return Ok(coupon);
        }

        [HttpGet("GetCouponByCode/{code}")]
        public IActionResult GetCouponByCode(string code)
        {
            var coupon = appDbContext.Coupons.FirstOrDefault(c => c.CouponCode == code);
            _mapper.Map<CouponDTO>(coupon);
            if (coupon == null)
            {
                return NotFound();
            }
            return Ok(coupon);
        }

        [HttpPost]
        public IActionResult CreateCoupon([FromBody] CouponDTO couponDTO)
        {
            var coupon = _mapper.Map<Coupon>(couponDTO);
            appDbContext.Coupons.Add(coupon);
            appDbContext.SaveChanges();
            return CreatedAtAction(nameof(GetCouponById), new { id = coupon.Id }, coupon);
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
