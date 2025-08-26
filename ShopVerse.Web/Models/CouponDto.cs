namespace ShopVerse.Web.Models
{
    public class CouponDto
    {
        public string? CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
