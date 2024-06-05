using ManagerBook.Infrastructure;
using ManagerBook.Core.Entities;
using Microsoft.EntityFrameworkCore;
using ManagerBook.DTO;

namespace ManagerBook.Application.Services
{
    public class StoreServices
    {
        private readonly ManagerBookDbContext _managerBookDbContext;

        public StoreServices(ManagerBookDbContext managerBookDbContext)

        {
            _managerBookDbContext = managerBookDbContext;
        }

        public async Task<List<Store>> GetAsync()
        {
            var result = await _managerBookDbContext.Stores.ToListAsync();

            return result;
        }
        public async Task<Store> GetByIdAsync(Guid Id)
        {
            var result = await _managerBookDbContext.Stores.SingleOrDefaultAsync(p => p.Id == Id);

            return result;
        }

        public async Task<Store> AddAsync(StoreDTO storeDTO)
        {
            var store = new Store
            {
                Id = storeDTO.Id,
                Email = storeDTO.Email
            };

            var result = await _managerBookDbContext.Stores.AddAsync(store);

            await _managerBookDbContext.SaveChangesAsync();

            return store;
        }

    }
}
