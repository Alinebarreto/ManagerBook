using ManagerBook.Core.Entities;
using ManagerBook.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManagerBook.Infrastructure.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly ManagerBookDbContext _dbContext;
        public StoreRepository(ManagerBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Store>> GetAll() 
        {
            return await _dbContext.Stores.ToListAsync();
        }
        public async Task<Store> GetByIdAsync (Guid Id) 
        {
            return await _dbContext.Stores.SingleOrDefaultAsync(p => p.Id == Id);
        }

        public async Task AddAsync (Store item) 
        {
            await _dbContext.Stores.AddAsync(item);
        }
    }
}
