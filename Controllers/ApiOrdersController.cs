using ECommerce.Models.Dtos;
using ECommerce.Services.Interfaces;
using ECommerce.Wrapper;
using ECommerce.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApiOrdersController : ControllerBase
{
    private readonly IApiOrdersService _apiOrdersService;
    private readonly ECommerceDbContext _context;
    public ApiOrdersController(IApiOrdersService apiOrdersService, ECommerceDbContext context)
    {
        _apiOrdersService = apiOrdersService;
        _context = context;
    }

    [HttpPost("Orders")]
    public async Task<IActionResult> PostOrder([FromBody] List<OrderDto> newOrders)
    {
        RowCounter rowCounter = await _apiOrdersService.AddNewOrderAsync(newOrders);
        ResponseHeaderHelper.AddRowInfoHeaders(Response.Headers, rowCounter);
        return Ok();
    }

    [HttpDelete("Orders")]
    public IActionResult DeleteAll()
    {
        _context.Orders.ExecuteDelete();
        return Ok();
    }
}
