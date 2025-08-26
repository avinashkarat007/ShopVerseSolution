using ShopVerse.Web.Models;

namespace ShopVerse.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDTO, bool withBearer = true);
    }
}
