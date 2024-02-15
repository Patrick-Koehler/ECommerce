using ECommerce.Data;
using ECommerce.Services.Interfaces;

namespace ECommerce.Services
{
    public class ApiOrdersService : IApiOrdersService
    {
        private readonly ECommerceDbContext _context;
        public ApiOrdersService(ECommerceDbContext context)
        {
            _context = context;
        }


    }
}
