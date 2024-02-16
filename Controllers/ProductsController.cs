using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.IdentityModel.Tokens;
using ECommerce.Data;
using System.Globalization;

namespace ECommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ECommerceDbContext _context;
        public ProductsController(ECommerceDbContext context)
        {
            _context = context;
        }
        public IActionResult ProductOverview()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult ProductDetails(Guid id)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == id);
            if (product != null)
            {
                return View(product);
            }
            else
            {
                return View();
            }
        }

        public IActionResult CreateEditProduct(Product product, IFormFile file)
        {
            if(product.Id == Guid.Empty)
            {
                _context.Products.Add(product);
            }
            else
            {
                var productFromDb = _context.Products.SingleOrDefault(x => x.Id == product.Id);
                if(productFromDb == null)
                {
                    return NotFound();
                }
            }
            
            
            _context.SaveChanges();

            return RedirectToAction("ProductDetails");
        }

        public IActionResult CreateProductImage(Configuration configuration, IFormFile file)
        {
            if(file != null)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var bytes = ms.ToArray();
                    configuration.CompanyImage = bytes;
                };
            }

            return RedirectToAction("ProductDetails");
        }

    }
}
