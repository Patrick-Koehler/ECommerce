namespace ECommerce.Services.Interfaces
{
    public interface IApiErrorHandlerService
    {
        public Task AddAsync(Exception ex, string functionName);
    }
}
