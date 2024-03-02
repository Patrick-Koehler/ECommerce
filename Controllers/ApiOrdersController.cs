using ECommerce.Models.Dtos;
using ECommerce.Services.Interfaces;
using ECommerce.Wrapper;
using ECommerce.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers;

[Route("[controller]")]
[ApiController]
public class ApiOrdersController : ControllerBase
{
    private readonly IApiOrdersService _apiOrdersService;
    public ApiOrdersController(IApiOrdersService apiOrdersService)
    {
        _apiOrdersService = apiOrdersService;
    }

    [HttpPost]
    public async Task<IActionResult> PostOrder([FromBody] OrderDto newOrder)
    {
        RowCounter rowCounter = await _apiOrdersService.AddNewOrderAsync(newOrder);
        ResponseHeadersHelper.AddRowInfoHeaders(Response.Headers, rowCounter);
        return Ok();
    }

    [HttpDelete("All")]
    public async Task <IActionResult> DeleteOrdersAll()
    {
        RowCounter rowCounter = await _apiOrdersService.DeleteOrdersAllAsync();
        ResponseHeadersHelper.AddRowInfoHeaders(Response.Headers, rowCounter);
        return Ok();
    }

    [HttpDelete("ByOrderNumber")]
    public IActionResult DeleteOrdersById([FromBody] Guid id)
    {
        return Ok();
    }
}
