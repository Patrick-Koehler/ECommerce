using ECommerce.Models;
using ECommerce.Models.Dtos;
using ECommerce.Wrapper;

namespace ECommerce.Services.Interfaces
{
    public interface IApiProductsService
    {
        public Task AddNewProductsAsync(List<ProductDto> newProducts);
    }
}
