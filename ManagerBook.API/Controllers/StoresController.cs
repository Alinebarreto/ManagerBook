using ManagerBook.Application.Services;
using ManagerBook.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ManagerBook.API.Controllers
{
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly StoreServices _storeServices;
        public StoresController(StoreServices StoreServices)
        {
            _storeServices = StoreServices;
        }

        [HttpPost]
        [Route("api/Stores/")]
        public async Task<IActionResult>AddAsync(StoreDTO storeDTO) 
        {
            var result = await _storeServices.AddAsync(storeDTO);

            return Ok(result);

        }

        [HttpGet]
        [Route("api/Stores/")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _storeServices.GetAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("api/Stores/{id=id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var result = await _storeServices.GetByIdAsync(id);

            return Ok(result);
        }
    }
}

