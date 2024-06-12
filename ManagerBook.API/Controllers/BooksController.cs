using ManagerBook.Application.Services;
using ManagerBook.Core.Entities;
using ManagerBook.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManagerBook.API.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookServices _bookServices;
        public BooksController(BookServices bookServices)
        {
            _bookServices = bookServices;
        }

        [HttpGet]
        [Route("api/Books/")]
        public async Task<ActionResult>GetBooks() 
        {
            var result = await _bookServices.GetAll();

            return Ok(result);
        }

        [HttpGet]
        [Route("api/Books/{id=id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var result = await _bookServices.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost]
        [Route("api/Books/")]
        public async Task<ActionResult>RegisterAsync (BookDTO dto)
        {
            var result = await _bookServices.AddAsync(dto);

            return Ok(result);
        }

        [HttpDelete]
        [Route("api/Books/{id=id}")]
        public async Task<ActionResult> RemoveAsync(BookDTO dto)
        {
            var result = await _bookServices.RemoveAsync(dto);

            return Ok(result);
        }
    }
}
