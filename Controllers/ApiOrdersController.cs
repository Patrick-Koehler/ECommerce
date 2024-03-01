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
    public ApiOrdersController(IApiOrdersService apiOrdersService)
    {
        _apiOrdersService = apiOrdersService;
    }

    [HttpPost("Orders")]
    public async Task<IActionResult> PostOrder([FromBody] List<OrderDto> newOrders)
    {
        RowCounter rowCounter = await _apiOrdersService.AddNewOrderAsync(newOrders);
        ResponseHeadersHelper.AddRowInfoHeaders(Response.Headers, rowCounter);
        return Ok();
    }

    [HttpDelete("Orders/All")]
    public async Task <IActionResult> DeleteOrdersAll()
    {
        await _apiOrdersService.DeleteOrdersAll();
        return Ok();
    }

    [HttpDelete("Orders/ById")]
    public IActionResult DeleteOrdersById([FromBody] Guid id)
    {
        return Ok();
    }
}
