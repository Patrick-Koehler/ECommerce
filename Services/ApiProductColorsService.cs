using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Models.Dtos;
using ECommerce.Services.Interfaces;
using ECommerce.Wrapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Services
{
    public class ApiProductColorsService : IApiProductColorsService
    {
        private readonly ECommerceDbContext _context;
        public ApiProductColorsService(ECommerceDbContext context)
        {
            _context = context;
        }

        //public async Task<RowCounter> AddNewProductColorAsync(List<ProductColorDto> newProductColors)
        //{
        //    RowCounter rowCounter = new();
        //    DateTime current = DateTime.Now;
        //    foreach(ProductColorDto newProductColor in newProductColors)
        //    {
        //        ProductColor productColor = new()
        //        {
        //            Id = Guid.NewGuid(),
        //            Description = newProductColor.Description,
        //            Created = current,
        //            Modified = null
        //        };
        //        _context.ProductColors.Add(productColor);
        //        rowCounter.AddedRows++;
        //    }
        //    _context.SaveChanges();            
        //    return rowCounter;
        //}
    }
}
