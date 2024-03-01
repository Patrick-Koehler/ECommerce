using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Models.Dtos;
using ECommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ECommerce.Services
{
    public class ApiCustomersService : IApiCustomersService
    {
        private readonly ECommerceDbContext _context;
        public ApiCustomersService(ECommerceDbContext context)
        {
            _context = context;
        }

        public bool CustomerExists(CustomerDto customer)
        {
            return _context.Customers.Any(x => x.FirstName == customer.FirstName && x.LastName == customer.LastName
                                            && x.Email == customer.Email && x.Birthday == customer.Birthday);
        }

        public bool HasValidForeignKeys(CustomerDto customer)
        {
            return false; //string.IsNullOrEmpty(customer.Street) || _context.DeliveryAdresses.Any(x => x.Street == customer.Street);
        }

        public async Task AddNewCustomerAsync(List<CustomerDto> newCustomers)
        {
            foreach (var newCustomer in newCustomers)
            {
                DateTime currentTime = DateTime.Now;
                Customer customer = new()
                {
                    Id = Guid.NewGuid(),
                    CustomerNumber = newCustomer.CustomerNumber,
                    FirstName = newCustomer.FirstName,
                    LastName = newCustomer.LastName,
                    Street = newCustomer.Street,
                    City = newCustomer.City,
                    Zip = newCustomer.Zip,
                    Phonenumber = newCustomer.Phonenumber,
                    Email = newCustomer.Email,
                    Birthday = newCustomer.Birthday,
                    CustomerSince = newCustomer.CustomerSince,
                    Info = newCustomer.Info,
                    IsOneTimeCustomer = newCustomer.IsOneTimeCustomer,
                    Created = currentTime,
                    Modified = null
                };
                await _context.Customers.AddAsync(customer);
            }
            _context.SaveChanges();
            return;
        }
    }
}
