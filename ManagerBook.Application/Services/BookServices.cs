using ManagerBook.Core.Entities;
using ManagerBook.DTO;
using ManagerBook.Infrastructure;
using ManagerBook.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ManagerBook.Application.Services
{
    public class BookServices
    {
        private readonly ManagerBookDbContext _managerBookDbContext;
     
     public BookServices(ManagerBookDbContext managerBookDbContext) 

        {
            _managerBookDbContext = managerBookDbContext;
        }

      public async Task<List<Book>> GetBooksAsync() 
        {
            var result = await _managerBookDbContext.Books.ToListAsync();
            return result;
        }

        public async Task<Book> GetBookAsync(Guid Id)
        {
            var result = await _managerBookDbContext.Books.Where(p => p.Id == Id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Book> AddBookAsync(BookDTO bookDTO)
        {
            var book = new Book 
            { Id = bookDTO.Id,
              Title = bookDTO.Title,
              Author = bookDTO.Author,
              ISBN = bookDTO.ISBN,
              YearPublished = bookDTO.YearPublished
            };

            var result = await _managerBookDbContext.Books.AddAsync(book);
            await _managerBookDbContext.SaveChangesAsync();
            return book;
        }
        public async Task<Book> RemoveBookAsync(BookDTO bookDTO)
        {
            var book = new Book
            {
                Id = bookDTO.Id,
                Title = bookDTO.Title,
                Author = bookDTO.Author,
                ISBN = bookDTO.ISBN,
                YearPublished = bookDTO.YearPublished
            };

            var result = _managerBookDbContext.Books.Remove(book);
            await _managerBookDbContext.SaveChangesAsync();
            return book;
        }

        //public async Task<Book> UpdateBookAsync(BookDTO bookDTO)
        //{
        //    var book = new Book
        //    {
        //        Id = bookDTO.Id,
        //        Title = bookDTO.Title,
        //        Author = bookDTO.Author,
        //        ISBN = bookDTO.ISBN,
        //        YearPublished = bookDTO.YearPublished
        //    };

        //    var result = _managerBookDbContext.Books.Update (book);
        //    await _managerBookDbContext.SaveChangesAsync();
        //    return book;
        //}

    }
}
