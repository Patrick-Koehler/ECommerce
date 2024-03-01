using ECommerce.Models.Dtos;

namespace ECommerce.Services.Interfaces
{
    public interface IApiCustomersService
    {
        public bool CustomerExists(CustomerDto customer);
        public bool HasValidForeignKeys(CustomerDto customer);
        public Task AddNewCustomerAsync(List<CustomerDto> newCustomers);
    }
}
