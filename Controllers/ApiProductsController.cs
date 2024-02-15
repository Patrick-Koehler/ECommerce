using ECommerce.Data;
using ECommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using ECommerce.Models;

namespace ECommerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApiProductsController : ControllerBase
{

    //private readonly IApiProductsService _apiProductsService;
    private readonly ECommerceDbContext _context;
    public ApiProductsController(ECommerceDbContext context/*, IApiProductsService apiProductsService*/)
    {
        _context = context;
        //_apiProductsService = apiProductsService;
    }

    #region Products
    /// <summary>
    /// Gets a List of Products from Database.
    /// </summary>
    [HttpGet("GetAll")]
    public IActionResult GetProductsAllAsync()
    {
        var allProducts = _context.Products.ToList();

        return Ok(allProducts);
    }
    #endregion

    #region Products/Colors
    /// <summary>
    /// Posts a List of ProductColors to Database.
    /// </summary>
    [HttpPost("ProductColors")]
    public IActionResult PostProductColorsAsync([FromBody] List<Models.ProductColor> colors)
    {
        DateTime current = DateTime.Now;
        foreach(var color in colors)
        {
            Models.ProductColor newColor = new()
            {
                Id = Guid.NewGuid(),
                Description = color.Description,
                Created = current,
                Modified = null
            };
            _context.ProductColors.Add(newColor);
        }        
        _context.SaveChanges();

        return Ok();
    }

    #endregion

    #region Products/Sizes

    #endregion

    #region Products/ProductImages

    #endregion
}
