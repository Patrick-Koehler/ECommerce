using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Models.Dtos;
using ECommerce.Services.Interfaces;

namespace ECommerce.Services
{
    public class ApiProductsService : IApiProductsService
    {
        private readonly ECommerceDbContext _context;
        public ApiProductsService(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task AddNewProductsAsync(List<ProductDto> newProducts)
        {
            foreach(var newProduct in newProducts)
            {
                //DateTime current = DateTime.Now;
                Product product = new()
                {
                    Id = Guid.NewGuid(),
                    ProductNumber = newProduct.ProductNumber,
                    Description = newProduct.Description,
                    Color = newProduct.Color,
                    Size = newProduct.Size,
                    ClassificationSchemeGroup = newProduct.ClassificationSchemeGroup,
                    Cathegory = newProduct.Cathegory,
                    Manufacturer = newProduct.Manufacturer,
                    IsBike = newProduct.IsBike,
                    IsMain = newProduct.IsMain,
                    AvailableFrom = newProduct.AvailableFrom,
                    Modified = null
                };
                _context.Products.Add(product);
            }
            await _context.SaveChangesAsync();
        }
    }
}
