using ManagerBook.Core.Entities;
using ManagerBook.Core.Repositories;
using ManagerBook.DTO;

namespace ManagerBook.Application.Services
{
    public class StoreServices
    {
        private readonly IDbRepository _dbRepository;
        private readonly IStoreRepository _storeRepository;

        public StoreServices(IDbRepository dbRepository, IStoreRepository storeRepository)

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
