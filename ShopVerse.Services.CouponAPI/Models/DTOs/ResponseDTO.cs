namespace ShopVerse.Services.CouponAPI.Models.DTOs
{
    public class ResponseDTO
    {
        public object? Result { get; set; }

        public bool IsSuccess { get; set; } = true;

        public List<string>? ErrorMessages { get; set; }
    }
}
