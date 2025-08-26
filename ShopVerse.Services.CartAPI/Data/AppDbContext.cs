using Microsoft.EntityFrameworkCore;
using ShopVerse.Services.CartAPI.Models;
using System.Collections.Generic;

namespace ShopVerse.Services.CartAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }

    }
}
