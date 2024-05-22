using ManagerBook.Application.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ManagerBook.API.Configuration
{
    public static class Services
    {
        public static void ServicesSetup(this IServiceCollection services) 
        {
            services.TryAddScoped<BookServices>();
            services.TryAddScoped<LoanServices>();
            services.TryAddScoped<UserServices>();
        }
    }
}
