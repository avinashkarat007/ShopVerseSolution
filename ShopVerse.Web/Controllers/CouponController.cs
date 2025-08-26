using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopVerse.Web.Models;
using ShopVerse.Web.Service.IService;

namespace ShopVerse.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService) {
            _couponService = couponService;
        }

        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDto> couponList = new List<CouponDto>();

            var couponsResponse = await _couponService.GetAllCoupons();

            if (couponsResponse!= null)
            {
                couponList = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(couponsResponse.Result));
            }

            return View(couponList);
        }

        public async Task<IActionResult> CouponCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _couponService.CreateCoupnAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Coupon created successfully";
                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }

    }
}
