using ManagerBook.Core.Entities;
using ManagerBook.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ManagerBook.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ManagerBookDbContext _dbContext;
        public BookRepository(ManagerBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Book>> GetAll() 
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(Guid Id) 
        {
            return await _dbContext.Books.SingleOrDefaultAsync(p => p.Id == Id);
        }

        public async Task AddAsync(Book item) 
        {
            await _dbContext.Books.AddAsync(item);
        }

        public async Task Remove(Book item)
        {
            _dbContext.Books.Remove(item);
        }

        public async Task<Book> UpdateAsync(Book item)
        {
            _dbContext.Books.Update(item);

            return item;
        }
    }
}
