using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TriCommerce.Models;

namespace ECommerce.Data
{
    public class ECommerceDbContext : DbContext//Template Standard :IdentityDbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ErrorMessage> ErrorMessages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductInformation> ProductInformations { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductPrice>()
                .Property(p => p.PurchasePriceNet)
                .HasPrecision(18, 2);
            modelBuilder.Entity<ProductPrice>()
                .Property(p => p.PurchasePrice)
                .HasPrecision(18, 2);
            modelBuilder.Entity<ProductPrice>()
                .Property(p => p.RRP)
                .HasPrecision(18, 2);
            modelBuilder.Entity<ProductPrice>()
                .Property(p => p.RetailPriceNet)
                .HasPrecision(18, 2);
            modelBuilder.Entity<ProductPrice>()
                .Property(p => p.RetailPrice)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Product>()
                .Property(p => p.RetailPrice)
                .HasPrecision(18, 2);
            modelBuilder.Entity<Product>()
                .Property(p => p.RRP)
                .HasPrecision(18, 2);
        }
    }
}
