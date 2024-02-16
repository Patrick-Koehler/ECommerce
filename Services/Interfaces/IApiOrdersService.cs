using ECommerce.Models.Dtos;
using ECommerce.Wrapper;

namespace ECommerce.Services.Interfaces
{
    public interface IApiOrdersService
    {
        public Task<RowCounter> AddNewOrderAsync(List<OrderDto> newOrders);
    }
}
