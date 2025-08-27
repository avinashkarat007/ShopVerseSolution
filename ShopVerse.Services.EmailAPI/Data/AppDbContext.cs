using Microsoft.EntityFrameworkCore;
using ShopVerse.Services.EmailAPI.Models;

namespace ShopVerse.Services.EmailAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<EmailLogger> EmailLoggers { get; set; }


    }
}
