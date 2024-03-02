using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using ECommerce.Data;

namespace ECommerce.Controllers;

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

    public IActionResult CreateEditProduct(Product product)
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

    public IActionResult AddProductImage(ProductImage productImage, IFormFile file)
    {
        DateTime current = DateTime.Now;
        if(file != null)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var bytes = ms.ToArray();
                productImage.ImageData = bytes;
                productImage.Created = current;
            };
            _context.ProductImages.Add(productImage);
            _context.SaveChanges();
        }

        return RedirectToAction("ProductDetails");
    }

}
