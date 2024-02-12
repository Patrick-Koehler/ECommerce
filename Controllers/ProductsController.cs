using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.IdentityModel.Tokens;
using ECommerce.Data;

namespace ECommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ECommerceDbContext _context;
        public ProductsController(ECommerceDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateEditProduct(Guid id)
        {
            return View();
        }

        public IActionResult AddProduct(Product product)
        { 
            return RedirectToAction("CreateEditProduct");
        }
    }
}
