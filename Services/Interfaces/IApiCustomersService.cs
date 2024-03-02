using ECommerce.Models.Dtos;
using ECommerce.Wrapper;

namespace ECommerce.Services.Interfaces
{
    public interface IApiCustomersService
    {
        public bool CustomerExists(CustomerDto customer);
        public bool HasValidForeignKeys(CustomerDto customer);
        public Task<RowCounter> AddNewCustomersAsync(List<CustomerDto> newCustomers);
        public Task<RowCounter> DeleteCustomersByCustomerNumberAsync(string[] customers);
        public Task<RowCounter> DeleteCustomersAllAsync();
    }
}
