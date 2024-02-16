using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ECommerce.Models;

namespace ECommerce.Data
{
    public class ECommerceDbContext :IdentityDbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options)
            : base(options)
        {
        }

        public DbSet<ClassificationSchemeGroup> ClassificationSchemeGroups { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ErrorMessage> ErrorMessages { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductInformation> ProductInformations { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ProductPrice>()
        //        .Property(p => p.PurchasePriceNet)
        //        .HasPrecision(18, 2);
        //    modelBuilder.Entity<ProductPrice>()
        //        .Property(p => p.PurchasePrice)
        //        .HasPrecision(18, 2);
        //    modelBuilder.Entity<ProductPrice>()
        //        .Property(p => p.RRP)
        //        .HasPrecision(18, 2);
        //    modelBuilder.Entity<ProductPrice>()
        //        .Property(p => p.RetailPriceNet)
        //        .HasPrecision(18, 2);
        //    modelBuilder.Entity<ProductPrice>()
        //        .Property(p => p.RetailPrice)
        //        .HasPrecision(18, 2);
        //    modelBuilder.Entity<Product>()
        //        .Property(p => p.RetailPrice)
        //        .HasPrecision(18, 2);
        //    modelBuilder.Entity<Product>()
        //        .Property(p => p.RRP)
        //        .HasPrecision(18, 2);
        //}
    }
}
