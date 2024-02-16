using ECommerce.Models.Dtos;
using ECommerce.Services.Interfaces;
using ECommerce.Wrapper;
using ECommerce.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        ResponseHeaderHelper.AddRowInfoHeaders(Response.Headers, rowCounter);
        return Ok();
    }
}
