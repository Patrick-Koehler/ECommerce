using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewCreateEditProducts(Guid id)
        {
            return View();
        }

        public IActionResult CreateEditProduct(Product product)
        {

        }
    }
}
