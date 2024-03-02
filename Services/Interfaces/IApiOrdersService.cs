using ECommerce.Models.Dtos;
using ECommerce.Wrapper;

namespace ECommerce.Services.Interfaces
{
    public interface IApiOrdersService
    {
        public Task<RowCounter> AddNewOrderAsync(OrderDto newOrder);
        public Task<RowCounter> DeleteOrdersAllAsync();
    }
}
