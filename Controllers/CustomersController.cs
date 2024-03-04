using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers;

public class CustomersController : Controller
{
    readonly ECommerceDbContext _context;
    public CustomersController(ECommerceDbContext context)
    {
        _context = context;
    }

    public IActionResult CustomerOverview()
    {
        return View();
    }

    public IActionResult CustomerDetails(Guid id)
    {
        return View();
    }

    public IActionResult CreateCustomer(Customer customer)
    {
        if (customer.CustomerNumber == null)
        {

            _context.Customers.Add(customer);
        }
        _context.SaveChanges();

        return RedirectToAction("CustomerDetails");
    }
}
