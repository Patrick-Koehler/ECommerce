using ECommerce.Data;
using ECommerce.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using ECommerce.Models;
using ECommerce.Models.Dtos;

namespace ECommerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApiProductsController : ControllerBase
{
    private readonly ECommerceDbContext _context;
    public ApiProductsController(ECommerceDbContext context)
    {
        _context = context;
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
    public IActionResult PostProductColorsAsync([FromBody] List<ProductColorDto> newColors)
    {
        DateTime current = DateTime.Now;
        foreach (var newColor in newColors)
        {
            ProductColor color = new()
            {
                Id = Guid.NewGuid(),
                Description = newColor.Description,
                Created = current,
                Modified = null
            };
            _context.ProductColors.Add(color);
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
