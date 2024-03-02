using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Models.Dtos;
using ECommerce.Services.Interfaces;
using ECommerce.Wrapper;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services
{
    public class ApiProductsService : IApiProductsService
    {
        private readonly ECommerceDbContext _context;
        public ApiProductsService(ECommerceDbContext context)
        {
            _context = context;
        }

        public ProductDto ToProductDto(Product product)
        {
            return new ProductDto()
            {
                Id = product.Id,
                ProductNumber = product.ProductNumber,
                Description = product.Description,
                Color = product.Color,
                Size = product.Size,
                ClassificationSchemeGroup = product.ClassificationSchemeGroup,
                Cathegory = product.Cathegory,
                Manufacturer = product.Manufacturer,
                IsBike = product.IsBike,
                IsMain = product.IsMain,
                AvailableFrom = product.AvailableFrom
            };
        }

        public async Task<List<ProductDto>> GetProductsAllAsync()
        {
            List<Product> productList = await _context.Products.ToListAsync();
            List<ProductDto> productDtoList = new();

            foreach (var product in productList)
            {
                productDtoList.Add(ToProductDto(product));
            }

            return productDtoList;
        }

        public async Task<RowCounter> AddNewProductsAsync(List<ProductDto> newProducts)
        {
            RowCounter rowCounter = new();
            foreach(var newProduct in newProducts)
            {
                //DateTime current = DateTime.Now;
                Product product = new()
                {
                    Id = Guid.NewGuid(),
                    ProductNumber = newProduct.ProductNumber,
                    Description = newProduct.Description,
                    Description2 = null,
                    Color = newProduct.Color,
                    Size = newProduct.Size,
                    ClassificationSchemeGroup = newProduct.ClassificationSchemeGroup,
                    Cathegory = newProduct.Cathegory,
                    EAN = null,
                    Manufacturer = newProduct.Manufacturer,
                    ManufacturerNumber = null,
                    IsBike = newProduct.IsBike,
                    IsMain = newProduct.IsMain,
                    DescriptionLong = null,
                    AvailableFrom = newProduct.AvailableFrom,
                    RetailPrice = 1,
                    RRP = 2,
                    Created = DateTime.Now,
                    Modified = null
                };
                _context.Products.Add(product);
                rowCounter.AddedRows++;
            }
            await _context.SaveChangesAsync();
            return (rowCounter);
        }

        public async Task<RowCounter> DeleteProductsByIdAsync(Guid[] ids)
        {
            RowCounter rowCounter = new();
            foreach(var id in ids)
            {
                rowCounter.DeletedRows += await _context.Products.Where(x => x.Id == id).ExecuteDeleteAsync();
            }
            return rowCounter;
        }

        public async Task<RowCounter> DeleteProductsAllAsync()
        {
            RowCounter rowCounter = new();
            rowCounter.DeletedRows += await _context.Products.ExecuteDeleteAsync();
            return rowCounter;
        }
    }
}
