using ECommerce.Helpers;
using ECommerce.Models.Dtos;
using ECommerce.Services;
using ECommerce.Services.Interfaces;
using ECommerce.Wrapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace ECommerce.Controllers;

[Route("[controller]")]
[ApiController]
public class ApiCustomersController : Controller
{
    private readonly ILogger _logger;
    private readonly IApiErrorHandlerService _apiErrorHandlerService;
    private readonly IApiCustomersService _apiCustomersService;
    public ApiCustomersController(ILogger<CustomersController> logger, IApiErrorHandlerService apiErrorHandlerService, IApiCustomersService apiCustomerService)
    {
        _logger = logger;
        _apiErrorHandlerService = apiErrorHandlerService;
        _apiCustomersService = apiCustomerService;
    }

    /// <summary>
    /// Posts a List of Customers to Database.
    /// Notice: Generally checks for already existing Customers.
    /// <param name="newCustomers">New Data to be inserted.</param>
    /// <param name="useValidation">Decides whether to validate the given Data before inserting. Default is true.</param>
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> PostCustomer([FromBody] List<CustomerDto> newCustomers, [FromQuery] bool useValidation = true)
    {
        try
        {
            _logger.LogInformation("Received Post Request for Customers");
            if (newCustomers.IsNullOrEmpty())
            {
                _logger.LogInformation("The given Customers list was empty! -> BadRequest");
                return BadRequest("The given Customers list was empty!");
            }
            List<CustomerDto> alreadyExist = new();
            List<CustomerDto> invalidForeignKeys = new();
            foreach (var newCustomer in newCustomers)
            {
                if (_apiCustomersService.CustomerExists(newCustomer))
                {
                    alreadyExist.Add(newCustomer);
                }
                if (useValidation)
                {
                    if (!_apiCustomersService.CustomerHasValidForeignKeys(newCustomer))
                    {
                        invalidForeignKeys.Add(newCustomer);
                    }
                }

            }

            if (!alreadyExist.IsNullOrEmpty())
            {
                _logger.LogInformation("Did not add any of the new Data because the following Customers already exist:\n{AlreadyExisting}\n-> BadRequest", JsonSerializer.Serialize(alreadyExist));
                return BadRequest($"Did not add any of the new Data because the following Customers already exist:\n{JsonSerializer.Serialize(alreadyExist)}\nUse Put to update existing Customers!");
            }
            if (!invalidForeignKeys.IsNullOrEmpty())
            {
                _logger.LogInformation("Did not add any of the new Data because the following Customers contain at least one invalid ForeignKey:\n{WithInvalidForeignKeys}\n-> BadRequest", JsonSerializer.Serialize(invalidForeignKeys));
                return BadRequest($"Did not add any of the new Data because the following Customers contain at least one invalid ForeignKey:\n{JsonSerializer.Serialize(invalidForeignKeys)}");
            }

            RowCounter rowCounter = await _apiCustomersService.AddNewCustomersAsync(newCustomers);
            ResponseHeadersHelper.AddRowInfoHeaders(Response.Headers, rowCounter);
            _logger.LogInformation("Deletion successful! Deleted Rows: {DeletedRows}", rowCounter.AddedRows);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error:\n{Ex}", ex);
            await _apiErrorHandlerService.AddAsync(ex, "PostCustomerAsync").ConfigureAwait(false);
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error:\n{ex}");
        }
    }

    /// <summary>
    /// Deletes Customers by a given List of CustomerNumbers.
    /// <param name="customerNumbers">List of CustomerNumbers whose Customers will be deleted.</param>
    /// </summary>
    [HttpDelete("ByCustomerNumber")]
    public async Task<IActionResult> DeleteCustomersByCustomerNumber (string[] customerNumbers)
    {
        try
        {
            _logger.LogInformation("Received DeleteByCustomerNumber Request for Customers");
            RowCounter rowCounter = await _apiCustomersService.DeleteCustomersByCustomerNumberAsync(customerNumbers);
            ResponseHeadersHelper.AddRowInfoHeaders(Response.Headers, rowCounter);
            _logger.LogInformation("Deletion successful! Deleted Rows: {DeletedRows}", rowCounter.DeletedRows);
            return NoContent();

        }
        catch (Exception ex)
        {
            _logger.LogError("Error:\n{Ex}", ex);
            await _apiErrorHandlerService.AddAsync(ex, "DeleteAllCustomersAsync").ConfigureAwait(false);
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error:\n{ex}");
        }
    }


    /// <summary>
    /// Deletes all rows from the Customers table and DeliveryAdress table.
    /// </summary>
    [HttpDelete("All")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    // Replaces CustomersDeleteAll
    public async Task<IActionResult> DeleteAllBuyersAsync()
    {
        try
        {
            _logger.LogInformation("Received DeleteAll Request for Buyers");
            RowCounter rowCounter = await _apiCustomersService.DeleteCustomersAllAsync();
            ResponseHeadersHelper.AddRowInfoHeaders(Response.Headers, rowCounter);
            _logger.LogInformation("Deletion successful! Deleted Rows: {DeletedRows}", rowCounter.DeletedRows);
            return NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError("Error:\n{Ex}", ex);
            await _apiErrorHandlerService.AddAsync(ex, "DeleteAllCustomersAsync").ConfigureAwait(false);
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error:\n{ex}");
        }
    }
}
