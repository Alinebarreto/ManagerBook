using ManagerBook.Core.Entities;
using ManagerBook.DTO;
using ManagerBook.Infrastructure.Repositories;

namespace ManagerBook.Application.Services
{
    public class BookServices
    {
        private readonly DbRepository _dbRepository;
        private readonly BookRepository _bookRepository;
     
        public BookServices(DbRepository dbRepository, BookRepository bookRepository) 
        {
            _bookRepository = bookRepository;
            _dbRepository = dbRepository;
        }

        public async Task<List<Book>> GetAll() 
        {
            var result = await _bookRepository.GetAll();

            return result;
        }

        public async Task<Book> GetByIdAsync(Guid Id)
        {
            var result = await _bookRepository.GetByIdAsync(Id);

            return result;
        }

        public async Task<Book> AddAsync(BookDTO bookDTO)
        {
            var book = new Book 

            { Id = bookDTO.Id,
              Title = bookDTO.Title,
              Author = bookDTO.Author,
              ISBN = bookDTO.ISBN,
              YearPublished = bookDTO.YearPublished,
              Stock = bookDTO.Stock,
              StoreId = bookDTO.StoreId
            };

            await _bookRepository.AddAsync(book);
            
            await _dbRepository.SaveChangesAsync();

            return book;
        }

        public async Task<Book> RemoveAsync(BookDTO bookDTO)
        {
            var book = new Book
            {
                Id = bookDTO.Id,
                Title = bookDTO.Title,
                Author = bookDTO.Author,
                ISBN = bookDTO.ISBN,
                YearPublished = bookDTO.YearPublished,
                Stock = bookDTO.Stock,
                StoreId = bookDTO.StoreId
            };

            await _bookRepository.Remove(book);

            await _dbRepository.SaveChangesAsync();

            return book;
        }
    }
}
