using ShopVerse.Services.CartAPI.Models.Dto;

namespace ShopVerse.Services.CartAPI.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
