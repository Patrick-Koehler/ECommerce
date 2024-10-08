﻿using ECommerce.Data;
using ECommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models.Dtos;
using ECommerce.Models;
using ECommerce.Helpers;
using ECommerce.Wrapper;

namespace ECommerce.Controllers;

[Route("[Controller]")]
[ApiController]
public class ApiProductsController : ControllerBase
{
    private readonly IApiProductsService _apiProductsService;
    private readonly IApiProductColorsService _apiProductColorsService;
 
    public ApiProductsController(IApiProductsService apiProductsService, IApiProductColorsService apiProductColorsService)
    {
        _apiProductsService = apiProductsService;
        _apiProductColorsService = apiProductColorsService;
    }

    #region Products
    /// <summary>
    /// Gets a List of Products from Database.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<ProductDto>> GetProductsAll()
    {
        List<ProductDto> productDtos = await _apiProductsService.GetProductsAllAsync();
        return Ok(productDtos);
    }

    /// <summary>
    /// Posts a List of given Products to Database.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PostProducts([FromBody] List<ProductDto> products)
    {

        RowCounter rowCounter = await _apiProductsService.AddNewProductsAsync(products);
        ResponseHeadersHelper.AddRowInfoHeaders(Response.Headers, rowCounter);
        return Ok();
    }

    /// <summary>
    /// Deletes specific rows from the Products table by Id.
    /// </summary>
    /// <param name="ids">List of SellerItemId's to be deleted.</param>
    [HttpDelete("ById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteProductsByIdAsync([FromBody] Guid[] ids)
    {
        RowCounter rowCounter = await _apiProductsService.DeleteProductsByIdAsync(ids);
        ResponseHeadersHelper.AddRowInfoHeaders(Response.Headers, rowCounter); 
        return Ok();
    }

    /// <summary>
    /// Deletes all Products from Databasee.
    /// </summary>
    [HttpDelete("All")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteProductsAllAsync()
    {
        RowCounter rowCounter = await _apiProductsService.DeleteProductsAllAsync();
        ResponseHeadersHelper.AddRowInfoHeaders(Response.Headers, rowCounter);

        return NoContent();
    }

    #endregion

    #region Products/Colors
    /// <summary>
    /// Posts a List of ProductColors to Database.
    /// </summary>
    [HttpPost("Colors")]
    public async Task<IActionResult> PostProductColors([FromBody] List<ProductColorDto> newProductColors)
    {
        RowCounter rowCounter = await _apiProductColorsService.AddNewProductColorAsync(newProductColors);
        ResponseHeadersHelper.AddRowInfoHeaders(Response.Headers, rowCounter);
        return Ok();
    }
    #endregion

    #region Products/Sizes

    #endregion

    #region Products/ProductImages

    #endregion
}
