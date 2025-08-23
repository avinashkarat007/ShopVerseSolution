namespace ShopVerse.Services.CouponAPI.Models.DTOs
{
    public class CouponDTO
    {
        public int Id { get; set; }
        public string? CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
