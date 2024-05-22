using ManagerBook.Application.Services;
using ManagerBook.Core.Entities;
using ManagerBook.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManagerBook.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookServices _bookServices;
        public BooksController(BookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpGet(Name = "GetAllBooks")]
            public async Task<ActionResult>GetBooks() 
        {
            var result = await _bookServices.GetBooksAsync();
            return Ok(result);
        }

        [HttpGet(Name = "GetBook")]
        public async Task<ActionResult> GetBook(Guid Id)
        {
            var result = await _bookServices.GetBookAsync(Id);
            return Ok(result);
        }

        [HttpPost(Name = "PostBook")]
        public async Task<ActionResult>RegisterBookAsync (BookDTO dto)
        {
            var result = await _bookServices.AddBookAsync(dto);
            return Ok(result);
        }

        [HttpDelete(Name = "DeleteBook")]
        public async Task<ActionResult> RemoveBookAsync(BookDTO dto)
        {
            var result = await _bookServices.RemoveBookAsync(dto);
            return Ok(result);
        }

        //[HttpPut(Name = "UpdateBook")]
        //public async Task<ActionResult> UpdateBookAsync(BookDTO dto)
        //{
        //    var result = await _bookServices.UpdateBookAsync(dto);
        //    return Ok(result);
        //}
    }
}
