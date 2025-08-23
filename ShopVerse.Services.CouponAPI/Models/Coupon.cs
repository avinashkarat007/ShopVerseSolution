using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ShopVerse.Services.CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? CouponCode { get; set; }

        [Required]
        [Precision(18, 2)]  // Requires EF Core 6+
        public decimal DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
