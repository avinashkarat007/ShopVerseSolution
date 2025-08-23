using Microsoft.EntityFrameworkCore;
using ShopVerse.Services.CouponAPI.Models;

namespace ShopVerse.Services.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, CouponCode = "15OFF", DiscountAmount = 15, MinAmount = 50 }
            );

            modelBuilder.Entity<Coupon>().HasData(new Coupon { Id = 2, CouponCode = "20OFF", DiscountAmount = 20, MinAmount = 75 });
        }
    }
        
}
