using Microsoft.AspNetCore.Identity;

namespace ShopVerse.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
