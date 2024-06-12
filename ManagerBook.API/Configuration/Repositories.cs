using ManagerBook.Core.Repositories;
using ManagerBook.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ManagerBook.API.Configuration
{
    public static class Repositories
    {
        public static void RepositoriesSetup(this IServiceCollection services) 
        {
            services.TryAddScoped<IDbRepository, DbRepository>();
            services.TryAddScoped<IBookRepository, BookRepository>();
            services.TryAddScoped<IUserRepository, UserRepository>();
            services.TryAddScoped<ILoanRepository, LoanRepository>();
            services.TryAddScoped<IStoreRepository, StoreRepository>();
        }
    }
}
