using ECommerce.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProductsController : ControllerBase
    {
        private readonly ECommerceDbContext _context;
        public ApiProductsController(ECommerceDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetProductsAllAsync()
        {
            var allProducts = _context.Products.ToList();

            return Ok(allProducts);
        }
    }
}
