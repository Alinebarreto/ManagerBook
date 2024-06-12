using ManagerBook.Core.Entities;
using ManagerBook.DTO;
using ManagerBook.Infrastructure.Repositories;

namespace ManagerBook.Application.Services
{
    public class StoreServices
    {
        private readonly DbRepository _dbRepository;
        private readonly StoreRepository _storeRepository;

        public StoreServices(DbRepository dbRepository, StoreRepository storeRepository)

        {   
            _storeRepository = storeRepository;
            _dbRepository = dbRepository;
        }

        public async Task<List<Store>> GetAsync()
        {
            var result = await _storeRepository.GetAll();

            return result;
        }
        public async Task<Store> GetByIdAsync(Guid Id)
        {
            var result = await _storeRepository.GetByIdAsync(Id);

            return result;
        }

        public async Task<Store> AddAsync(StoreDTO storeDTO)
        {
            var store = new Store
            {
                Id = storeDTO.Id,
                Email = storeDTO.Email
            };

            await _storeRepository.AddAsync(store);

            await _dbRepository.SaveChangesAsync();

            return store;
        }

    }
}
