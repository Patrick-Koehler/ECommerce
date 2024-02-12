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
            //Prüfen ob Id bereits gesetzt. 
            if(product.Id == Guid.Empty)
            {
                //Add new product if not editing
                _context.Products.Add(product);
            }
            else
            {
                
                //Update existing product if !Guid.Empty
                //_context.Products.Update(product);

                var productInDb = _context.Products.SingleOrDefault(x => x.Id == product.Id);
                

                if (productInDb == null)
                {
                    return NotFound();
                }

                DateTime createdDateTime;
                if (DateTime.TryParseExact("01.01.2000 00:00:00", "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out createdDateTime))
                {
                    productInDb.Created = createdDateTime;
                }
                productInDb.Id = product.Id;
                productInDb.ProductNumber = product.ProductNumber;
                productInDb.ProductDescription = product.ProductDescription;
                productInDb.ProductDescription2 = product.ProductDescription2;
                productInDb.EAN = product.EAN;
                productInDb.AvailableFrom = createdDateTime;
                productInDb.Created = createdDateTime;
                productInDb.Modified = createdDateTime;

            }
            _context.SaveChanges();

            return RedirectToAction("CreateEditProduct");
        }
    }
}
