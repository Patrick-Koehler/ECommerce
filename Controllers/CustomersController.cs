using ECommerce.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult CustomerOverview()
        {
            return View();
        }

        public IActionResult CustomerDetails()
        {
            return View();
        }
    }
}
