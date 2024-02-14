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

            return View();
        }

        public IActionResult ProductDetails(Guid id)
        {
            return View();
        }

        public IActionResult CreateEditProduct(Product product)
        {
            if(product.Id == Guid.Empty)
            {
                //Add new product if not existing
                if (product.ProductNumber == null)
                {
                    product.ProductNumber = "11111";
                }
                if (product.ProductDescription == null)
                {
                    product.ProductDescription = "Hello World";
                }
                _context.Products.Add(product);
            }
            else
            {
                var productFromDb = _context.Products.SingleOrDefault(x => x.Id == product.Id);
                if(productFromDb == null)
                {
                    return NotFound();
                }
                else
                {
                    
                }
            }
            
            
            _context.SaveChanges();

            return RedirectToAction("CreateEditProduct");
        }
    }
}
