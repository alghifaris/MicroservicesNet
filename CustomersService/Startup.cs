using CustomersService.Controllers.Services;
using Microsoft.AspNetCore.Builder;

namespace CustomersService
{
    public class Startup
    {
        private readonly IServiceProvider _startupContainer;

        public Startup(IServiceProvider startupContainer)
        {
            _startupContainer = startupContainer;
        }
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
