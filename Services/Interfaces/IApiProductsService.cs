using ECommerce.Models;
using ECommerce.Models.Dtos;
using ECommerce.Wrapper;

namespace ECommerce.Services.Interfaces
{
    public interface IApiProductsService
    {
        public ProductDto ToProductDto(Product product);
        public Task<List<ProductDto>> GetProductsAllAsync();
        public Task<RowCounter> AddNewProductsAsync(List<ProductDto> newProducts);
        public Task<RowCounter> DeleteProductsByIdAsync(Guid[] ids);
        public Task<RowCounter> DeleteProductsAllAsync();
    }
}
