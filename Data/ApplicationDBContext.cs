using Microsoft.EntityFrameworkCore;
using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace api.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>  
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Portfolio>(x => x.HasKey(p => new { p.AppUserId, p.StockId }));

            builder.Entity<Portfolio>().HasOne(u => u.AppUser).WithMany(u =>u.Portfolios).HasForeignKey(p => p.AppUserId);
            
            builder.Entity<Portfolio>().HasOne(u => u.Stock).WithMany(u =>u.Portfolios).HasForeignKey(p => p.StockId);

            List<IdentityRole> roles =
            [
                new() {
                    Id = "f5b5c3c1-2b7e-4d60-9c8f-0d9e70d18e3a",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                 new() {
                    Id = "e3f6c9b2-4f9d-4c3a-bc99-5c5893c9056f",
                    Name = "User",
                    NormalizedName = "USER"
                },
            ];
            
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
