using ManagerBook.Core.Entities;

namespace ManagerBook.Core.Repositories
{
    public interface IStoreRepository
    {
        Task<List<Store>> GetAll();
        Task<Store> GetByIdAsync(Guid Id);
        Task AddAsync(Store item);
    }
}
