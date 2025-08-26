using ShopVerse.Services.AuthAPI.Models;

namespace ShopVerse.Services.AuthAPI.Services.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
