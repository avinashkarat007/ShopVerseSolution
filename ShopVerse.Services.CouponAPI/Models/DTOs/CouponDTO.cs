namespace ShopVerse.Services.CouponAPI.Models.DTOs
{
    public class CouponDTO
    {
        public string? CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
