using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Models.Dtos;
using ECommerce.Services.Interfaces;
using ECommerce.Wrapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

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
            return _context.Customers.Any(x => x.CustomerNumber == customer.CustomerNumber && x.FirstName == customer.FirstName
                                            && x.LastName == customer.LastName && x.Email == customer.Email && x.Birthday == customer.Birthday);
        }

        public bool HasValidForeignKeys(CustomerDto customer)
        {
            return true; //string.IsNullOrEmpty(customer.Street) || _context.DeliveryAdresses.Any(x => x.Street == customer.Street);
        }

        public async Task<RowCounter> AddNewCustomersAsync(List<CustomerDto> newCustomers)
        {
            RowCounter rowCounter = new();
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
                    UserId = newCustomer.UserId,
                    UserPassword = newCustomer.UserPassword,
                    Created = currentTime,
                    Modified = null
                };
                await _context.Customers.AddAsync(customer);
                rowCounter.AddedRows++;

                if (newCustomer.DeliveryAdress != null)
                {
                    DeliveryAdress deliveryAdress = new()
                    {
                        Id = Guid.NewGuid(),
                        CustomerId = customer.Id,
                        FirstName = newCustomer.DeliveryAdress.FirstName,
                        LastName = newCustomer.DeliveryAdress.LastName,
                        Street = newCustomer.DeliveryAdress.Street,
                        City = newCustomer.DeliveryAdress.City,
                        Zip = newCustomer.DeliveryAdress.Zip,
                        Phonenumber = newCustomer.DeliveryAdress.Phonenumber,
                        Email = newCustomer.DeliveryAdress.Email,
                        IsMain = newCustomer.DeliveryAdress.IsMain,
                        Created = currentTime,
                        Modified = null
                    };
                    await _context.DeliveryAdresses.AddAsync(deliveryAdress);
                    rowCounter.AddedRows++;
                }
            }
            _context.SaveChanges();
            return rowCounter;
        }

        public async Task<RowCounter> DeleteCustomersByCustomerNumberAsync(string[] customerNumbers)
        {
            RowCounter rowCounter = new();
            {
                foreach (var customerNumber in customerNumbers)
                {
                    Customer customer = _context.Customers.Single(x => x.CustomerNumber == customerNumber);
                    rowCounter.DeletedRows += await _context.DeliveryAdresses.Where(y => y.CustomerId == customer.Id).ExecuteDeleteAsync();
                    rowCounter.DeletedRows += await _context.Customers.Where(y => y.Id == customer.Id).ExecuteDeleteAsync();
                }
                
            }
            return rowCounter;
        }

        public async Task<RowCounter> DeleteCustomersAllAsync()
        {
            RowCounter rowCounter = new();
            _context.Database.SetCommandTimeout(4444);
            rowCounter.DeletedRows += await _context.DeliveryAdresses.ExecuteDeleteAsync();
            rowCounter.DeletedRows += await _context.Customers.ExecuteDeleteAsync();
            _context.Database.SetCommandTimeout(null);
            return rowCounter;
        }
    }
}
