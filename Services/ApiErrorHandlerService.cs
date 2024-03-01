using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Services.Interfaces;

namespace ECommerce.Services
{
    public class ApiErrorHandlerService : IApiErrorHandlerService
    {
        private readonly ECommerceDbContext _context;
        public ApiErrorHandlerService(ECommerceDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a new ErrorMessage object into the Database.
        /// </summary>
        /// <param name="ex">Error that was thrown.</param>
        /// <param name="functionName">Name of the function the Error occured in.</param>
        /// <returns></returns>
        public async Task AddAsync(Exception ex, string functionName)
        {
            ErrorMessage newErrorMessage = new()
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                FunctionName = functionName,
                ErrorCode = ex.HResult,
                UserAgent = "BackendRest"
            };
            if (!string.IsNullOrEmpty(ex.Message))
                newErrorMessage.Message = ex.Message;
            if (ex.InnerException != null)
            {
                string innerExString = ex.InnerException.ToString();
                newErrorMessage.InnerException = innerExString.Length > 250 ? innerExString.Remove(250) : innerExString;
            }
            await _context.ErrorMessages.AddAsync(newErrorMessage);
            await _context.SaveChangesAsync();
        }
    }
}
