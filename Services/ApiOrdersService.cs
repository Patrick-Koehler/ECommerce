using ECommerce.Data;
using ECommerce.Helpers;
using ECommerce.Models;
using ECommerce.Models.Dtos;
using ECommerce.Services.Interfaces;
using ECommerce.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services
{
    public class ApiOrdersService : IApiOrdersService
    {
        private readonly ECommerceDbContext _context;
        public ApiOrdersService(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<RowCounter> AddNewOrderAsync(List<OrderDto> newOrders)
        {
            RowCounter rowCounter = new();
            DateTime current = DateTime.Now;
            foreach(var newOrder in newOrders)
            {
                Order order = new()
                {
                    Id = Guid.NewGuid(),
                    CustomerId = Guid.Empty,
                    DeliveryAdress = Guid.Empty,
                    OrderState = OrderStatus.Recieved.ToString(),
                    IsNew = true,
                    IsPayed = newOrder.IsPayed,
                    Payment = newOrder.Payment,
                    IsCompleted = false,
                    OrderRecievedDate = current,
                    Created = current,
                    Modified = null,
                    Reference = newOrder.Reference,
                    TrackingNumber = newOrder.TrackingNumber,
                    Notice = newOrder.Notice,

                };
                _context.Orders.Add(order);
                rowCounter.AddedRows++;
            }
            await _context.SaveChangesAsync();
            return rowCounter;
        }

        public async Task DeleteOrdersAll()
        {
            await _context.Products.ExecuteDeleteAsync();
        }
    }
}
