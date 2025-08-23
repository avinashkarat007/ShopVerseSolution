using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopVerse.Services.CouponAPI.Data;

namespace ShopVerse.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public CouponAPIController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet]
        public IActionResult GetCoupons()
        {
            var copupons = appDbContext.Coupons.ToList();

            return Ok(copupons);
        }
    }
}
