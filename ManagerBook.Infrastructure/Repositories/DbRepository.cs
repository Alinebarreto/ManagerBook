using ManagerBook.Core.Repositories;

namespace ManagerBook.Infrastructure.Repositories
{
    public class DbRepository : IDbRepository
    {
        private readonly ManagerBookDbContext _dbContext;

        public DbRepository(ManagerBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task SaveChangesAsync()
        {
            _dbContext.SaveChangesAsync();
        }
    }
}
