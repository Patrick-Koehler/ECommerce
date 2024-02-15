using ECommerce.Data;
using ECommerce.Models.Dtos;
using ECommerce.Services.Interfaces;

namespace ECommerce.Services
{
    public class ApiProductColorsService : IApiProductColorsService
    {
        private readonly ECommerceDbContext _context;
        public ApiProductColorsService(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task AddNewProductColor(ProductColorDto newProductColors)
        {
            DateTime current = DateTime.Now;

        }

    }
}
