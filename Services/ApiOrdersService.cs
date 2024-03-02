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

        public async Task<RowCounter> AddNewOrderAsync(OrderDto newOrder)
        {
            RowCounter rowCounter = new();
            Order order = new()
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.Empty,
                DeliveryAdressId = Guid.Empty,
                OrderState = OrderStatus.Recieved.ToString(),
                IsNew = true,
                IsPayed = newOrder.IsPayed,
                Payment = newOrder.Payment,
                IsCompleted = false,
                OrderRecievedDate = DateTime.Now,
                Created = DateTime.Now,
                Modified = null,
                Reference = newOrder.Reference,
                TrackingNumber = newOrder.TrackingNumber,
                Notice = newOrder.Notice,

            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            rowCounter.AddedRows++;
            return rowCounter;
        }

        public async Task<RowCounter> DeleteOrdersAllAsync()
        {
            RowCounter rowCounter = new();
            rowCounter.DeletedRows = await _context.Products.ExecuteDeleteAsync();
            return rowCounter;
        }
    }
}
