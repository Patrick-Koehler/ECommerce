using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult OrderOverview()
        {
            return View();
        }

        public IActionResult OrderDetails()
        {
            return View();
        }
    }
}
