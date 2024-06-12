using ManagerBook.Core.Entities;

namespace ManagerBook.Core.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();
        Task<Book> GetByIdAsync(Guid Id);
        Task AddAsync(Book item);
        Task Remove(Book item);

        Task<Book> UpdateAsync(Book item);

    }
}
