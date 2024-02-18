using ECommerce.Models.Dtos;
using ECommerce.Wrapper;

namespace ECommerce.Services.Interfaces
{
    public interface IApiProductColorsService
    {
        public Task<RowCounter> AddNewProductColorAsync(List<ProductColorDto> newProductColors);
    }
}
